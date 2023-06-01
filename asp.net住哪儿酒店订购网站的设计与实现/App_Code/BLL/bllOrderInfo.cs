using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*����ҵ���߼���*/
    public class bllOrderInfo{
        /*��Ӷ���*/
        public static bool AddOrderInfo(ENTITY.OrderInfo orderInfo)
        {
            return DAL.dalOrderInfo.AddOrderInfo(orderInfo);
        }

        /*����orderId��ȡĳ��������¼*/
        public static ENTITY.OrderInfo getSomeOrderInfo(int orderId)
        {
            return DAL.dalOrderInfo.getSomeOrderInfo(orderId);
        }

        /*���¶���*/
        public static bool EditOrderInfo(ENTITY.OrderInfo orderInfo)
        {
            return DAL.dalOrderInfo.EditOrderInfo(orderInfo);
        }

        /*ɾ������*/
        public static bool DelOrderInfo(string p)
        {
            return DAL.dalOrderInfo.DelOrderInfo(p);
        }

        /*��ѯ����*/
        public static System.Data.DataSet GetOrderInfo(string strWhere)
        {
            return DAL.dalOrderInfo.GetOrderInfo(strWhere);
        }

        /*����������ҳ��ѯ����*/
        public static System.Data.DataTable GetOrderInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalOrderInfo.GetOrderInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĶ���*/
        public static System.Data.DataSet getAllOrderInfo()
        {
            return DAL.dalOrderInfo.getAllOrderInfo();
        }
    }
}
