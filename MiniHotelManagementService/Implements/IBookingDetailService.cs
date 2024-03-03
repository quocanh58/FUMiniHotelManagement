using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHotelManagementService.Implements
{
    public interface IBookingDetailService
    {
        public List<BookingDetail> GetAllBookingDetails();
        public BookingDetail GetBookingDetailByRoomID(int id);
        public BookingDetail GetBookingDetailByBookingReservationID(int id);
    }
}
