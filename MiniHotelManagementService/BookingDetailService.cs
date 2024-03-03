using BusinessObject.Models;
using MiniHotelManagementRepository;
using MiniHotelManagementService.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHotelManagementService
{
    public class BookingDetailService : IBookingDetailService
    {
        private BookingDetailRepository _bookingDetailRepository;
        public BookingDetailService() => _bookingDetailRepository = new BookingDetailRepository();

        public List<BookingDetail> GetAllBookingDetails() => _bookingDetailRepository.GetAllBookingDetails();

        public BookingDetail GetBookingDetailByBookingReservationID(int id) => _bookingDetailRepository.GetBookingDetailByRoomID(id);

        public BookingDetail GetBookingDetailByRoomID(int id) => _bookingDetailRepository.GetBookingDetailByRoomID(id);
    }
}
