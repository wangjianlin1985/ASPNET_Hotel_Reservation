using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*地区业务逻辑层实现*/
    public class dalArea
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加地区实现*/
        public static bool AddArea(ENTITY.Area area)
        {
            string sql = "insert into Area(areanName) values(@areanName)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@areanName",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = area.areanName; //地区名称

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据areaId获取某条地区记录*/
        public static ENTITY.Area getSomeArea(int areaId)
        {
            /*构建查询sql*/
            string sql = "select * from Area where areaId=" + areaId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Area area = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                area = new ENTITY.Area();
                area.areaId = Convert.ToInt32(DataRead["areaId"]);
                area.areanName = DataRead["areanName"].ToString();
            }
            return area;
        }

        /*更新地区实现*/
        public static bool EditArea(ENTITY.Area area)
        {
            string sql = "update Area set areanName=@areanName where areaId=@areaId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@areanName",SqlDbType.VarChar),
             new SqlParameter("@areaId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = area.areanName;
            parm[1].Value = area.areaId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除地区*/
        public static bool DelArea(string p)
        {
            string sql = "delete from Area where areaId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询地区*/
        public static DataSet GetArea(string strWhere)
        {
            try
            {
                string strSql = "select * from Area" + strWhere + " order by areaId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询地区*/
        public static System.Data.DataTable GetArea(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Area";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "areaId", strShow, strSql, strWhere, " areaId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllArea()
        {
            try
            {
                string strSql = "select * from Area";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
