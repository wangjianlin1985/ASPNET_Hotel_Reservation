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
    ///Hotel ��ժҪ˵�����Ƶ�ʵ��
    /// </summary>

    public class Hotel
    {
        /*�Ƶ�id*/
        private int _hotelId;
        public int hotelId
        {
            get { return _hotelId; }
            set { _hotelId = value; }
        }

        /*���ڵ���*/
        private int _areaObj;
        public int areaObj
        {
            get { return _areaObj; }
            set { _areaObj = value; }
        }

        /*�Ƶ�����*/
        private string _hotelName;
        public string hotelName
        {
            get { return _hotelName; }
            set { _hotelName = value; }
        }

        /*�Ƶ���Ƭ*/
        private string _hotelPhoto;
        public string hotelPhoto
        {
            get { return _hotelPhoto; }
            set { _hotelPhoto = value; }
        }

        /*ÿ�ռ۸�*/
        private float _price;
        public float price
        {
            get { return _price; }
            set { _price = value; }
        }

        /*�Ƶ����*/
        private string _hotelDesc;
        public string hotelDesc
        {
            get { return _hotelDesc; }
            set { _hotelDesc = value; }
        }

        /*��ע��Ϣ*/
        private string _hotelMemo;
        public string hotelMemo
        {
            get { return _hotelMemo; }
            set { _hotelMemo = value; }
        }

        /*����ʱ��*/
        private DateTime _addTime;
        public DateTime addTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }

    }
}
