using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ENTITY
{
    /// <summary>
    ///Comment ��ժҪ˵��������ʵ��
    /// </summary>

    public class Comment
    {
        /*����id*/
        private int _commentId;
        public int commentId
        {
            get { return _commentId; }
            set { _commentId = value; }
        }

        /*�����Ƶ�*/
        private int _hotelObj;
        public int hotelObj
        {
            get { return _hotelObj; }
            set { _hotelObj = value; }
        }

        /*��������*/
        private string _content;
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }

        /*�����û�*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*����ʱ��*/
        private DateTime _commentTime;
        public DateTime commentTime
        {
            get { return _commentTime; }
            set { _commentTime = value; }
        }

    }
}
