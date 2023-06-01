using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*酒店业务逻辑层实现*/
    public class dalHotel
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加酒店实现*/
        public static bool AddHotel(ENTITY.Hotel hotel)
        {
            string sql = "insert into Hotel(areaObj,hotelName,hotelPhoto,price,hotelDesc,hotelMemo,addTime) values(@areaObj,@hotelName,@hotelPhoto,@price,@hotelDesc,@hotelMemo,@addTime)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@areaObj",SqlDbType.Int),
             new SqlParameter("@hotelName",SqlDbType.VarChar),
             new SqlParameter("@hotelPhoto",SqlDbType.VarChar),
             new SqlParameter("@price",SqlDbType.Float),
             new SqlParameter("@hotelDesc",SqlDbType.VarChar),
             new SqlParameter("@hotelMemo",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = hotel.areaObj; //所在地区
            parm[1].Value = hotel.hotelName; //酒店名称
            parm[2].Value = hotel.hotelPhoto; //酒店照片
            parm[3].Value = hotel.price; //每日价格
            parm[4].Value = hotel.hotelDesc; //酒店介绍
            parm[5].Value = hotel.hotelMemo; //备注信息
            parm[6].Value = hotel.addTime; //发布时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据hotelId获取某条酒店记录*/
        public static ENTITY.Hotel getSomeHotel(int hotelId)
        {
            /*构建查询sql*/
            string sql = "select * from Hotel where hotelId=" + hotelId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Hotel hotel = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                hotel = new ENTITY.Hotel();
                hotel.hotelId = Convert.ToInt32(DataRead["hotelId"]);
                hotel.areaObj = Convert.ToInt32(DataRead["areaObj"]);
                hotel.hotelName = DataRead["hotelName"].ToString();
                hotel.hotelPhoto = DataRead["hotelPhoto"].ToString();
                hotel.price = float.Parse(DataRead["price"].ToString());
                hotel.hotelDesc = DataRead["hotelDesc"].ToString();
                hotel.hotelMemo = DataRead["hotelMemo"].ToString();
                hotel.addTime = Convert.ToDateTime(DataRead["addTime"].ToString());
            }
            return hotel;
        }

        /*更新酒店实现*/
        public static bool EditHotel(ENTITY.Hotel hotel)
        {
            string sql = "update Hotel set areaObj=@areaObj,hotelName=@hotelName,hotelPhoto=@hotelPhoto,price=@price,hotelDesc=@hotelDesc,hotelMemo=@hotelMemo,addTime=@addTime where hotelId=@hotelId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@areaObj",SqlDbType.Int),
             new SqlParameter("@hotelName",SqlDbType.VarChar),
             new SqlParameter("@hotelPhoto",SqlDbType.VarChar),
             new SqlParameter("@price",SqlDbType.Float),
             new SqlParameter("@hotelDesc",SqlDbType.VarChar),
             new SqlParameter("@hotelMemo",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime),
             new SqlParameter("@hotelId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = hotel.areaObj;
            parm[1].Value = hotel.hotelName;
            parm[2].Value = hotel.hotelPhoto;
            parm[3].Value = hotel.price;
            parm[4].Value = hotel.hotelDesc;
            parm[5].Value = hotel.hotelMemo;
            parm[6].Value = hotel.addTime;
            parm[7].Value = hotel.hotelId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除酒店*/
        public static bool DelHotel(string p)
        {
            string sql = "delete from Hotel where hotelId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询酒店*/
        public static DataSet GetHotel(string strWhere)
        {
            try
            {
                string strSql = "select * from Hotel" + strWhere + " order by hotelId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询酒店*/
        public static System.Data.DataTable GetHotel(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Hotel";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "hotelId", strShow, strSql, strWhere, " hotelId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllHotel()
        {
            try
            {
                string strSql = "select * from Hotel";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
