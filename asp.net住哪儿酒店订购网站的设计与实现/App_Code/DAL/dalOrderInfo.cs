using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*����ҵ���߼���ʵ��*/
    public class dalOrderInfo
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��Ӷ���ʵ��*/
        public static bool AddOrderInfo(ENTITY.OrderInfo orderInfo)
        {
            string sql = "insert into OrderInfo(hotelObj,userObj,liveDate,orderDays,totalPrice,orderMemo,orderState,orderTime) values(@hotelObj,@userObj,@liveDate,@orderDays,@totalPrice,@orderMemo,@orderState,@orderTime)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@hotelObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@liveDate",SqlDbType.DateTime),
             new SqlParameter("@orderDays",SqlDbType.Int),
             new SqlParameter("@totalPrice",SqlDbType.Float),
             new SqlParameter("@orderMemo",SqlDbType.VarChar),
             new SqlParameter("@orderState",SqlDbType.VarChar),
             new SqlParameter("@orderTime",SqlDbType.DateTime)
            };
            /*��������ֵ*/
            parm[0].Value = orderInfo.hotelObj; //Ԥ���Ƶ�
            parm[1].Value = orderInfo.userObj; //Ԥ���û�
            parm[2].Value = orderInfo.liveDate; //��ס����
            parm[3].Value = orderInfo.orderDays; //��ס����
            parm[4].Value = orderInfo.totalPrice; //�����ܼ�
            parm[5].Value = orderInfo.orderMemo; //������ע
            parm[6].Value = orderInfo.orderState; //����״̬
            parm[7].Value = orderInfo.orderTime; //Ԥ��ʱ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����orderId��ȡĳ��������¼*/
        public static ENTITY.OrderInfo getSomeOrderInfo(int orderId)
        {
            /*������ѯsql*/
            string sql = "select * from OrderInfo where orderId=" + orderId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.OrderInfo orderInfo = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                orderInfo = new ENTITY.OrderInfo();
                orderInfo.orderId = Convert.ToInt32(DataRead["orderId"]);
                orderInfo.hotelObj = Convert.ToInt32(DataRead["hotelObj"]);
                orderInfo.userObj = DataRead["userObj"].ToString();
                orderInfo.liveDate = Convert.ToDateTime(DataRead["liveDate"].ToString());
                orderInfo.orderDays = Convert.ToInt32(DataRead["orderDays"]);
                orderInfo.totalPrice = float.Parse(DataRead["totalPrice"].ToString());
                orderInfo.orderMemo = DataRead["orderMemo"].ToString();
                orderInfo.orderState = DataRead["orderState"].ToString();
                orderInfo.orderTime = Convert.ToDateTime(DataRead["orderTime"].ToString());
            }
            return orderInfo;
        }

        /*���¶���ʵ��*/
        public static bool EditOrderInfo(ENTITY.OrderInfo orderInfo)
        {
            string sql = "update OrderInfo set hotelObj=@hotelObj,userObj=@userObj,liveDate=@liveDate,orderDays=@orderDays,totalPrice=@totalPrice,orderMemo=@orderMemo,orderState=@orderState,orderTime=@orderTime where orderId=@orderId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@hotelObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@liveDate",SqlDbType.DateTime),
             new SqlParameter("@orderDays",SqlDbType.Int),
             new SqlParameter("@totalPrice",SqlDbType.Float),
             new SqlParameter("@orderMemo",SqlDbType.VarChar),
             new SqlParameter("@orderState",SqlDbType.VarChar),
             new SqlParameter("@orderTime",SqlDbType.DateTime),
             new SqlParameter("@orderId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = orderInfo.hotelObj;
            parm[1].Value = orderInfo.userObj;
            parm[2].Value = orderInfo.liveDate;
            parm[3].Value = orderInfo.orderDays;
            parm[4].Value = orderInfo.totalPrice;
            parm[5].Value = orderInfo.orderMemo;
            parm[6].Value = orderInfo.orderState;
            parm[7].Value = orderInfo.orderTime;
            parm[8].Value = orderInfo.orderId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ������*/
        public static bool DelOrderInfo(string p)
        {
            string sql = "delete from OrderInfo where orderId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ����*/
        public static DataSet GetOrderInfo(string strWhere)
        {
            try
            {
                string strSql = "select * from OrderInfo" + strWhere + " order by orderId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ����*/
        public static System.Data.DataTable GetOrderInfo(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from OrderInfo";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "orderId", strShow, strSql, strWhere, " orderId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllOrderInfo()
        {
            try
            {
                string strSql = "select * from OrderInfo";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
