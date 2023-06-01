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
    ///Hotel 的摘要说明：酒店实体
    /// </summary>

    public class Hotel
    {
        /*酒店id*/
        private int _hotelId;
        public int hotelId
        {
            get { return _hotelId; }
            set { _hotelId = value; }
        }

        /*所在地区*/
        private int _areaObj;
        public int areaObj
        {
            get { return _areaObj; }
            set { _areaObj = value; }
        }

        /*酒店名称*/
        private string _hotelName;
        public string hotelName
        {
            get { return _hotelName; }
            set { _hotelName = value; }
        }

        /*酒店照片*/
        private string _hotelPhoto;
        public string hotelPhoto
        {
            get { return _hotelPhoto; }
            set { _hotelPhoto = value; }
        }

        /*每日价格*/
        private float _price;
        public float price
        {
            get { return _price; }
            set { _price = value; }
        }

        /*酒店介绍*/
        private string _hotelDesc;
        public string hotelDesc
        {
            get { return _hotelDesc; }
            set { _hotelDesc = value; }
        }

        /*备注信息*/
        private string _hotelMemo;
        public string hotelMemo
        {
            get { return _hotelMemo; }
            set { _hotelMemo = value; }
        }

        /*发布时间*/
        private DateTime _addTime;
        public DateTime addTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }

    }
}
