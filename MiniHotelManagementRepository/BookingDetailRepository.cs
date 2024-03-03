using BusinessObject.Models;
using MiniHotelManagementDAO;
using MiniHotelManagementRepository.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHotelManagementRepository
{
    public class BookingDetailRepository : IBookingDetailRepository
    {
        private BookingDetailDAO _bookingDetailDAO;
        public BookingDetailRepository() => _bookingDetailDAO = new BookingDetailDAO();

        public List<BookingDetail> GetAllBookingDetails() => _bookingDetailDAO.GetAllBookingDetails();

        public BookingDetail GetBookingDetailByBookingReservationID(int id) => _bookingDetailDAO.GetBookingDetailByRoomID(id);

        public BookingDetail GetBookingDetailByRoomID(int id) => _bookingDetailDAO.GetBookingDetailByRoomID(id);
    }
}
