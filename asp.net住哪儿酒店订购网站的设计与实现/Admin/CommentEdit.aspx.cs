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
    public partial class CommentEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindHotelhotelObj();
                BindUserInfouserObj();
                if (Request["commentId"] != null)
                {
                    LoadData();
                }
            }
        }
        private void BindHotelhotelObj()
        {
            hotelObj.DataSource = BLL.bllHotel.getAllHotel();
            hotelObj.DataTextField = "hotelName";
            hotelObj.DataValueField = "hotelId";
            hotelObj.DataBind();
        }

        private void BindUserInfouserObj()
        {
            userObj.DataSource = BLL.bllUserInfo.getAllUserInfo();
            userObj.DataTextField = "name";
            userObj.DataValueField = "user_name";
            userObj.DataBind();
        }

        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "commentId")))
            {
                ENTITY.Comment comment = BLL.bllComment.getSomeComment(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "commentId")));
                hotelObj.SelectedValue = comment.hotelObj.ToString();
                content.Value = comment.content;
                userObj.SelectedValue = comment.userObj;
                commentTime.Text = comment.commentTime.ToShortDateString() + " " + comment.commentTime.ToLongTimeString();
            }
        }

        protected void BtnCommentSave_Click(object sender, EventArgs e)
        {
            ENTITY.Comment comment = new ENTITY.Comment();
            comment.hotelObj = int.Parse(hotelObj.SelectedValue);
            comment.content = content.Value;
            comment.userObj = userObj.SelectedValue;
            comment.commentTime = Convert.ToDateTime(commentTime.Text);
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "commentId")))
            {
                comment.commentId = int.Parse(Request["commentId"]);
                if (BLL.bllComment.EditComment(comment))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"CommentEdit.aspx?commentId=" + Request["commentId"] + "\"} else  {location.href=\"CommentList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllComment.AddComment(comment))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"CommentEdit.aspx\"} else  {location.href=\"CommentList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CommentList.aspx");
        }
    }
}

