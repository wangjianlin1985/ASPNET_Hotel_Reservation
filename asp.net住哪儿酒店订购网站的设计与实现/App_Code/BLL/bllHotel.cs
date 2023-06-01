using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*酒店业务逻辑层*/
    public class bllHotel{
        /*添加酒店*/
        public static bool AddHotel(ENTITY.Hotel hotel)
        {
            return DAL.dalHotel.AddHotel(hotel);
        }

        /*根据hotelId获取某条酒店记录*/
        public static ENTITY.Hotel getSomeHotel(int hotelId)
        {
            return DAL.dalHotel.getSomeHotel(hotelId);
        }

        /*更新酒店*/
        public static bool EditHotel(ENTITY.Hotel hotel)
        {
            return DAL.dalHotel.EditHotel(hotel);
        }

        /*删除酒店*/
        public static bool DelHotel(string p)
        {
            return DAL.dalHotel.DelHotel(p);
        }

        /*查询酒店*/
        public static System.Data.DataSet GetHotel(string strWhere)
        {
            return DAL.dalHotel.GetHotel(strWhere);
        }

        /*根据条件分页查询酒店*/
        public static System.Data.DataTable GetHotel(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalHotel.GetHotel(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的酒店*/
        public static System.Data.DataSet getAllHotel()
        {
            return DAL.dalHotel.getAllHotel();
        }
    }
}
