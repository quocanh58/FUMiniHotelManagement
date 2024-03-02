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
    public class BookingReservationRepository : IBookingReservationRepository
    {
        private BookingReservationDAO _bookingReservationDAO;
        public BookingReservationRepository() => _bookingReservationDAO = new BookingReservationDAO();

        public bool CreateBookingReservation(int customerId, BookingReservation bookingReservation) => _bookingReservationDAO.CreateBookingReservation(customerId, bookingReservation);

        public List<BookingReservation> GetAllBookingReservations() => _bookingReservationDAO.GetAllBookingReservations();

        public BookingReservation GetBookingReservationByID(int id) => _bookingReservationDAO.GetBookingReservationByID(id);
    }
}
