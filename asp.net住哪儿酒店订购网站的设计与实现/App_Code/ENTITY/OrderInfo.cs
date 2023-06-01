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
    ///OrderInfo 的摘要说明：订单实体
    /// </summary>

    public class OrderInfo
    {
        /*订单id*/
        private int _orderId;
        public int orderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }

        /*预订酒店*/
        private int _hotelObj;
        public int hotelObj
        {
            get { return _hotelObj; }
            set { _hotelObj = value; }
        }

        /*预订用户*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*入住日期*/
        private DateTime _liveDate;
        public DateTime liveDate
        {
            get { return _liveDate; }
            set { _liveDate = value; }
        }

        /*入住天数*/
        private int _orderDays;
        public int orderDays
        {
            get { return _orderDays; }
            set { _orderDays = value; }
        }

        /*订单总价*/
        private float _totalPrice;
        public float totalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }

        /*订单备注*/
        private string _orderMemo;
        public string orderMemo
        {
            get { return _orderMemo; }
            set { _orderMemo = value; }
        }

        /*订单状态*/
        private string _orderState;
        public string orderState
        {
            get { return _orderState; }
            set { _orderState = value; }
        }

        /*预订时间*/
        private DateTime _orderTime;
        public DateTime orderTime
        {
            get { return _orderTime; }
            set { _orderTime = value; }
        }

    }
}
