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
    ///OrderInfo ��ժҪ˵��������ʵ��
    /// </summary>

    public class OrderInfo
    {
        /*����id*/
        private int _orderId;
        public int orderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }

        /*Ԥ���Ƶ�*/
        private int _hotelObj;
        public int hotelObj
        {
            get { return _hotelObj; }
            set { _hotelObj = value; }
        }

        /*Ԥ���û�*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*��ס����*/
        private DateTime _liveDate;
        public DateTime liveDate
        {
            get { return _liveDate; }
            set { _liveDate = value; }
        }

        /*��ס����*/
        private int _orderDays;
        public int orderDays
        {
            get { return _orderDays; }
            set { _orderDays = value; }
        }

        /*�����ܼ�*/
        private float _totalPrice;
        public float totalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }

        /*������ע*/
        private string _orderMemo;
        public string orderMemo
        {
            get { return _orderMemo; }
            set { _orderMemo = value; }
        }

        /*����״̬*/
        private string _orderState;
        public string orderState
        {
            get { return _orderState; }
            set { _orderState = value; }
        }

        /*Ԥ��ʱ��*/
        private DateTime _orderTime;
        public DateTime orderTime
        {
            get { return _orderTime; }
            set { _orderTime = value; }
        }

    }
}
