using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace chengxusheji.Admin
{
    public partial class HotelList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindareaObj();
                string sqlstr = " where 1=1 ";
                if (Request["areaObj"] != null && Request["areaObj"].ToString() != "0")
                {
                    sqlstr += "  and areaObj=" + Request["areaObj"].ToString();
                    areaObj.SelectedValue = Request["areaObj"].ToString();
                }
                if (Request["hotelName"] != null && Request["hotelName"].ToString() != "")
                {
                    sqlstr += "  and hotelName like '%" + Request["hotelName"].ToString() + "%'";
                    hotelName.Text = Request["hotelName"].ToString();
                }
                if (Request["addTime"] != null && Request["addTime"].ToString() != "")
                {
                    sqlstr += "  and Convert(varchar,addTime,120) like '" + Request["addTime"].ToString() + "%'";
                    addTime.Text = Request["addTime"].ToString();
                }
                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        private void BindareaObj()
        {
            ListItem li = new ListItem("不限制", "0");
            areaObj.Items.Add(li);
            DataSet areaObjDs = BLL.bllArea.getAllArea();
            for (int i = 0; i < areaObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = areaObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["areanName"].ToString(), dr["areanName"].ToString());
                areaObj.Items.Add(li);
            }
            areaObj.SelectedValue = "0";
        }

        protected void BtnHotelAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("HotelEdit.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllHotel.DelHotel(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "信息成功删除..", "HotelList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "error", "信息删除失败，请重试或联系管理人员..");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "error", "删除失败..");
                }
            }
        }

        private void BindData(string strClass)
        {
            int DataCount = 0;
            int NowPage = 1;
            int AllPage = 0;
            int PageSize = Convert.ToInt32(HPageSize.Value);
            switch (strClass)
            {
                case "next":
                    NowPage = Convert.ToInt32(HNowPage.Value) + 1;
                    break;
                case "up":
                    NowPage = Convert.ToInt32(HNowPage.Value) - 1;
                    break;
                case "end":
                    NowPage = Convert.ToInt32(HAllPage.Value);
                    break;
                default:
                    break;
            }
            DataTable dsLog = BLL.bllHotel.GetHotel(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
            if (dsLog.Rows.Count == 0 || AllPage == 1)
            {
                LBEnd.Enabled = false;
                LBHome.Enabled = false;
                LBNext.Enabled = false;
                LBUp.Enabled = false;
            }
            else if (NowPage == 1)
            {
                LBHome.Enabled = false;
                LBUp.Enabled = false;
                LBNext.Enabled = true;
                LBEnd.Enabled = true;
            }
            else if (NowPage == AllPage)
            {
                LBHome.Enabled = true;
                LBUp.Enabled = true;
                LBNext.Enabled = false;
                LBEnd.Enabled = false;
            }
            else
            {
                LBEnd.Enabled = true;
                LBHome.Enabled = true;
                LBNext.Enabled = true;
                LBUp.Enabled = true;
            }
            RpHotel.DataSource = dsLog;
            RpHotel.DataBind();
            PageMes.Text = string.Format("[每页<font color=green>{0}</font>条 第<font color=red>{1}</font>页／共<font color=green>{2}</font>页   共<font color=green>{3}</font>条]", PageSize, NowPage, AllPage, DataCount);
            HNowPage.Value = Convert.ToString(NowPage++);
            HAllPage.Value = AllPage.ToString();
        }

        protected void LBHome_Click(object sender, EventArgs e)
        {
            BindData("");
        }
        protected void LBUp_Click(object sender, EventArgs e)
        {
            BindData("up");
        }
        protected void LBNext_Click(object sender, EventArgs e)
        {
            BindData("next");
        }
        protected void LBEnd_Click(object sender, EventArgs e)
        {
            BindData("end");
        }
        protected void RpHotel_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllHotel.DelHotel((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除成功...", "HotelList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除失败，请重试或联系管理人员...", "HotelList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "删除失败...", "HotelList.aspx");
                }
            }
        }
        public string GetAreaareaObj(string areaObj)
        {
            return BLL.bllArea.getSomeArea(int.Parse(areaObj)).areanName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("HotelList.aspx?areaObj=" + areaObj.SelectedValue.Trim()+ "&&hotelName=" + hotelName.Text.Trim()+ "&&addTime=" + addTime.Text.Trim());
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet hotelDataSet = BLL.bllHotel.GetHotel(HWhere.Value); 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead><tr><th colSpan='6'>酒店记录</th></tr>");
            sb.Append("<tr class='title'>");
            sb.Append("<th>酒店id</th>");
            sb.Append("<th>所在地区</th>");
            sb.Append("<th>酒店名称</th>");
            sb.Append("<th>酒店照片</th>");
            sb.Append("<th>每日价格</th>");
            sb.Append("<th>发布时间</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            for (int i = 0; i < hotelDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow dr = hotelDataSet.Tables[0].Rows[i];
                sb.Append("<tr height='60' class=content>");
                sb.Append("<td>" + dr["hotelId"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllArea.getSomeArea(Convert.ToInt32(dr["areaObj"])).areanName + "</td>");
                sb.Append("<td>" + dr["hotelName"].ToString() + "</td>");
                sb.Append("<td width=80><span align='center'><img width='80' height='60' border='0' src='" + GetBaseUrl() + "/" +  dr["hotelPhoto"].ToString() + "'/></span></td>");
                sb.Append("<td>" + dr["price"].ToString() + "</td>");
                sb.Append("<td>" + Convert.ToDateTime(dr["addTime"]).ToShortDateString() + "</td>");
                sb.Append("</tr>");
            } 
           sb.Append("</tbody></table>");
            string content = sb.ToString();
            string css = ".content{color:red;text-align:center;}";
            string filename = "酒店记录.xls";
            CommonTool.ExportToExcel(filename, content, css);
        }

        protected string GetBaseUrl()
        {
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/Admin"));
        }
    }
}
