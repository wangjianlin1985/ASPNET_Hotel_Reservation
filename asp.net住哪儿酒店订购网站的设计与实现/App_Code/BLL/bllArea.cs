using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*地区业务逻辑层*/
    public class bllArea{
        /*添加地区*/
        public static bool AddArea(ENTITY.Area area)
        {
            return DAL.dalArea.AddArea(area);
        }

        /*根据areaId获取某条地区记录*/
        public static ENTITY.Area getSomeArea(int areaId)
        {
            return DAL.dalArea.getSomeArea(areaId);
        }

        /*更新地区*/
        public static bool EditArea(ENTITY.Area area)
        {
            return DAL.dalArea.EditArea(area);
        }

        /*删除地区*/
        public static bool DelArea(string p)
        {
            return DAL.dalArea.DelArea(p);
        }

        /*查询地区*/
        public static System.Data.DataSet GetArea(string strWhere)
        {
            return DAL.dalArea.GetArea(strWhere);
        }

        /*根据条件分页查询地区*/
        public static System.Data.DataTable GetArea(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalArea.GetArea(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的地区*/
        public static System.Data.DataSet getAllArea()
        {
            return DAL.dalArea.getAllArea();
        }
    }
}
