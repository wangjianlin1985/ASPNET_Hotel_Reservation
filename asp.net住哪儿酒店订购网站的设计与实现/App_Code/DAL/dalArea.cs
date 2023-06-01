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
    public class dalArea
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��ӵ���ʵ��*/
        public static bool AddArea(ENTITY.Area area)
        {
            string sql = "insert into Area(areanName) values(@areanName)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@areanName",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = area.areanName; //��������

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����areaId��ȡĳ��������¼*/
        public static ENTITY.Area getSomeArea(int areaId)
        {
            /*������ѯsql*/
            string sql = "select * from Area where areaId=" + areaId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Area area = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                area = new ENTITY.Area();
                area.areaId = Convert.ToInt32(DataRead["areaId"]);
                area.areanName = DataRead["areanName"].ToString();
            }
            return area;
        }

        /*���µ���ʵ��*/
        public static bool EditArea(ENTITY.Area area)
        {
            string sql = "update Area set areanName=@areanName where areaId=@areaId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@areanName",SqlDbType.VarChar),
             new SqlParameter("@areaId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = area.areanName;
            parm[1].Value = area.areaId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ������*/
        public static bool DelArea(string p)
        {
            string sql = "delete from Area where areaId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ����*/
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

        /*��ѯ����*/
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
