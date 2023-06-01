using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�Ƶ�ҵ���߼���*/
    public class bllHotel{
        /*��ӾƵ�*/
        public static bool AddHotel(ENTITY.Hotel hotel)
        {
            return DAL.dalHotel.AddHotel(hotel);
        }

        /*����hotelId��ȡĳ���Ƶ��¼*/
        public static ENTITY.Hotel getSomeHotel(int hotelId)
        {
            return DAL.dalHotel.getSomeHotel(hotelId);
        }

        /*���¾Ƶ�*/
        public static bool EditHotel(ENTITY.Hotel hotel)
        {
            return DAL.dalHotel.EditHotel(hotel);
        }

        /*ɾ���Ƶ�*/
        public static bool DelHotel(string p)
        {
            return DAL.dalHotel.DelHotel(p);
        }

        /*��ѯ�Ƶ�*/
        public static System.Data.DataSet GetHotel(string strWhere)
        {
            return DAL.dalHotel.GetHotel(strWhere);
        }

        /*����������ҳ��ѯ�Ƶ�*/
        public static System.Data.DataTable GetHotel(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalHotel.GetHotel(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еľƵ�*/
        public static System.Data.DataSet getAllHotel()
        {
            return DAL.dalHotel.getAllHotel();
        }
    }
}
