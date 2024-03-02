using BusinessObject.Models;
using MiniHotelManagementDAO;
using MiniHotelManagementRepository;
using MiniHotelManagementService.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHotelManagementService
{
    public class BookingReservationService : IBookingReservationService
    {
        private BookingReservationRepository _bookingReservation;
        public BookingReservationService() => _bookingReservation = new BookingReservationRepository();

        public bool CreateBookingReservation(int customerId, BookingReservation bookingReservation) => _bookingReservation.CreateBookingReservation(customerId, bookingReservation);

        public List<BookingReservation> GetAllBookingReservations() => _bookingReservation.GetAllBookingReservations();

        public BookingReservation GetBookingReservationByID(int id) => _bookingReservation.GetBookingReservationByID(id);
    }
}
