using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class OrderInfo_frontList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindhotelObj();
           
            string sqlstr = " where 1=1 ";
            if (Request["hotelObj"] != null && Request["hotelObj"].ToString() != "0")
            {
                    sqlstr += "  and hotelObj=" + Request["hotelObj"].ToString();
                    hotelObj.SelectedValue = Request["hotelObj"].ToString();
            }
            
            sqlstr += " and userObj='" + Session["user_name"].ToString() + "'";

            if (Request["liveDate"] != null && Request["liveDate"].ToString() != "")
            {
                sqlstr += "  and Convert(varchar,liveDate,120) like '" + Request["liveDate"].ToString() + "%'";
                liveDate.Text = Request["liveDate"].ToString();
            }
            if (Request["orderState"] != null && Request["orderState"].ToString() != "")
            {
                sqlstr += "  and orderState like '%" + Request["orderState"].ToString() + "%'";
                orderState.Text = Request["orderState"].ToString();
            }
            if (Request["orderTime"] != null && Request["orderTime"].ToString() != "")
            {
                sqlstr += "  and Convert(varchar,orderTime,120) like '" + Request["orderTime"].ToString() + "%'";
                orderTime.Text = Request["orderTime"].ToString();
            }
            HWhere.Value = sqlstr;
            BindData("");
       }
    }
    private void BindhotelObj()
    {
        ListItem li = new ListItem("不限制", "0");
        hotelObj.Items.Add(li);
        DataSet hotelObjDs = BLL.bllHotel.getAllHotel();
        for (int i = 0; i < hotelObjDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = hotelObjDs.Tables[0].Rows[i];
            li = new ListItem(dr["hotelName"].ToString(),dr["hotelId"].ToString());
            hotelObj.Items.Add(li);
        }
        hotelObj.SelectedValue = "0";
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
        DataTable dsLog = BLL.bllOrderInfo.GetOrderInfo(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
        RpOrderInfo.DataSource = dsLog;
        RpOrderInfo.DataBind();
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
        public string GetHotelhotelObj(string hotelObj)
        {
            return BLL.bllHotel.getSomeHotel(int.Parse(hotelObj)).hotelName;
        }

        public string GetUserInfouserObj(string userObj)
        {
            return BLL.bllUserInfo.getSomeUserInfo(userObj).name;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("frontUserList.aspx?hotelObj=" + hotelObj.SelectedValue.Trim() + "&&userObj=" + Session["user_name"].ToString() + "&&liveDate=" + liveDate.Text.Trim()+ "&&orderState=" + orderState.Text.Trim()+ "&&orderTime=" + orderTime.Text.Trim());
        }

}
