using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*订单业务逻辑层实现*/
    public class dalOrderInfo
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加订单实现*/
        public static bool AddOrderInfo(ENTITY.OrderInfo orderInfo)
        {
            string sql = "insert into OrderInfo(hotelObj,userObj,liveDate,orderDays,totalPrice,orderMemo,orderState,orderTime) values(@hotelObj,@userObj,@liveDate,@orderDays,@totalPrice,@orderMemo,@orderState,@orderTime)";
            /*构建sql参数*/
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
            /*给参数赋值*/
            parm[0].Value = orderInfo.hotelObj; //预订酒店
            parm[1].Value = orderInfo.userObj; //预订用户
            parm[2].Value = orderInfo.liveDate; //入住日期
            parm[3].Value = orderInfo.orderDays; //入住天数
            parm[4].Value = orderInfo.totalPrice; //订单总价
            parm[5].Value = orderInfo.orderMemo; //订单备注
            parm[6].Value = orderInfo.orderState; //订单状态
            parm[7].Value = orderInfo.orderTime; //预订时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据orderId获取某条订单记录*/
        public static ENTITY.OrderInfo getSomeOrderInfo(int orderId)
        {
            /*构建查询sql*/
            string sql = "select * from OrderInfo where orderId=" + orderId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.OrderInfo orderInfo = null;
            /*如果查询存在记录，就包装到对象中返回*/
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

        /*更新订单实现*/
        public static bool EditOrderInfo(ENTITY.OrderInfo orderInfo)
        {
            string sql = "update OrderInfo set hotelObj=@hotelObj,userObj=@userObj,liveDate=@liveDate,orderDays=@orderDays,totalPrice=@totalPrice,orderMemo=@orderMemo,orderState=@orderState,orderTime=@orderTime where orderId=@orderId";
            /*构建sql参数信息*/
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
            /*为参数赋值*/
            parm[0].Value = orderInfo.hotelObj;
            parm[1].Value = orderInfo.userObj;
            parm[2].Value = orderInfo.liveDate;
            parm[3].Value = orderInfo.orderDays;
            parm[4].Value = orderInfo.totalPrice;
            parm[5].Value = orderInfo.orderMemo;
            parm[6].Value = orderInfo.orderState;
            parm[7].Value = orderInfo.orderTime;
            parm[8].Value = orderInfo.orderId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除订单*/
        public static bool DelOrderInfo(string p)
        {
            string sql = "delete from OrderInfo where orderId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询订单*/
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

        /*查询订单*/
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
