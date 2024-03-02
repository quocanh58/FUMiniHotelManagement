using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHotelManagementRepository.Implements
{
    public interface IBookingReservationRepository
    {
        public bool CreateBookingReservation(int customerId, BookingReservation bookingReservation);
        public BookingReservation GetBookingReservationByID(int id);
        public List<BookingReservation> GetAllBookingReservations();
    }
}
