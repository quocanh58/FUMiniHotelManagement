using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHotelManagementDAO
{
    public class BookingDetailDAO
    {
        public static BookingDetailDAO instance = null;
        public static FuminiHotelManagementContext dbContex = null;

        public static BookingDetailDAO Instance()
        {
            if (instance == null)
            {
                instance = new BookingDetailDAO();
            }
            return instance;
        }

        public BookingDetailDAO()
        {
            dbContex = new FuminiHotelManagementContext();
        }

        public List<BookingDetail> GetAllBookingDetails()
        {
            try
            {
                var data = dbContex.BookingDetails.ToList();
                return data;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public BookingDetail GetBookingDetailByRoomID(int id)
        {
            try
            {
                var data = dbContex.BookingDetails.FirstOrDefault(x => x.RoomId == id);
                if (data != null)
                {
                    return data;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public BookingDetail GetBookingDetailByBookingReservationID(int id)
        {
            try
            {
                var data = dbContex.BookingDetails.FirstOrDefault(x => x.BookingReservationId == id);
                if (data != null)
                {
                    return data;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
