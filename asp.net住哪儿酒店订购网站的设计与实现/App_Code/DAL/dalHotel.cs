using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*�Ƶ�ҵ���߼���ʵ��*/
    public class dalHotel
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��ӾƵ�ʵ��*/
        public static bool AddHotel(ENTITY.Hotel hotel)
        {
            string sql = "insert into Hotel(areaObj,hotelName,hotelPhoto,price,hotelDesc,hotelMemo,addTime) values(@areaObj,@hotelName,@hotelPhoto,@price,@hotelDesc,@hotelMemo,@addTime)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@areaObj",SqlDbType.Int),
             new SqlParameter("@hotelName",SqlDbType.VarChar),
             new SqlParameter("@hotelPhoto",SqlDbType.VarChar),
             new SqlParameter("@price",SqlDbType.Float),
             new SqlParameter("@hotelDesc",SqlDbType.VarChar),
             new SqlParameter("@hotelMemo",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime)
            };
            /*��������ֵ*/
            parm[0].Value = hotel.areaObj; //���ڵ���
            parm[1].Value = hotel.hotelName; //�Ƶ�����
            parm[2].Value = hotel.hotelPhoto; //�Ƶ���Ƭ
            parm[3].Value = hotel.price; //ÿ�ռ۸�
            parm[4].Value = hotel.hotelDesc; //�Ƶ����
            parm[5].Value = hotel.hotelMemo; //��ע��Ϣ
            parm[6].Value = hotel.addTime; //����ʱ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����hotelId��ȡĳ���Ƶ��¼*/
        public static ENTITY.Hotel getSomeHotel(int hotelId)
        {
            /*������ѯsql*/
            string sql = "select * from Hotel where hotelId=" + hotelId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Hotel hotel = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*���¾Ƶ�ʵ��*/
        public static bool EditHotel(ENTITY.Hotel hotel)
        {
            string sql = "update Hotel set areaObj=@areaObj,hotelName=@hotelName,hotelPhoto=@hotelPhoto,price=@price,hotelDesc=@hotelDesc,hotelMemo=@hotelMemo,addTime=@addTime where hotelId=@hotelId";
            /*����sql������Ϣ*/
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
            /*Ϊ������ֵ*/
            parm[0].Value = hotel.areaObj;
            parm[1].Value = hotel.hotelName;
            parm[2].Value = hotel.hotelPhoto;
            parm[3].Value = hotel.price;
            parm[4].Value = hotel.hotelDesc;
            parm[5].Value = hotel.hotelMemo;
            parm[6].Value = hotel.addTime;
            parm[7].Value = hotel.hotelId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ���Ƶ�*/
        public static bool DelHotel(string p)
        {
            string sql = "delete from Hotel where hotelId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ�Ƶ�*/
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

        /*��ѯ�Ƶ�*/
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
