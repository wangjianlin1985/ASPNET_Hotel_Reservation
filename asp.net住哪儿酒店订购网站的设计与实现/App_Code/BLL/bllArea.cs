using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*����ҵ���߼���*/
    public class bllArea{
        /*��ӵ���*/
        public static bool AddArea(ENTITY.Area area)
        {
            return DAL.dalArea.AddArea(area);
        }

        /*����areaId��ȡĳ��������¼*/
        public static ENTITY.Area getSomeArea(int areaId)
        {
            return DAL.dalArea.getSomeArea(areaId);
        }

        /*���µ���*/
        public static bool EditArea(ENTITY.Area area)
        {
            return DAL.dalArea.EditArea(area);
        }

        /*ɾ������*/
        public static bool DelArea(string p)
        {
            return DAL.dalArea.DelArea(p);
        }

        /*��ѯ����*/
        public static System.Data.DataSet GetArea(string strWhere)
        {
            return DAL.dalArea.GetArea(strWhere);
        }

        /*����������ҳ��ѯ����*/
        public static System.Data.DataTable GetArea(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalArea.GetArea(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĵ���*/
        public static System.Data.DataSet getAllArea()
        {
            return DAL.dalArea.getAllArea();
        }
    }
}
