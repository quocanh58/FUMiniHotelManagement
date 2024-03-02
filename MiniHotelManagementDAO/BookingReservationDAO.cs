using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHotelManagementDAO
{
    public class BookingReservationDAO
    {
        public static BookingReservationDAO instance = null;
        public static FuminiHotelManagementContext dbContext = null;

        public BookingReservationDAO()
        {
            dbContext = new FuminiHotelManagementContext();
        }

        public static BookingReservationDAO Instance()
        {
            if (instance == null)
            {
                instance = new BookingReservationDAO();
            }
            return instance;
        }

        public List<BookingReservation> GetAllBookingReservations()
        {
            try
            {
                var list = dbContext.BookingReservations.ToList();
                return list;
            }
            catch (Exception)
            {
                throw new Exception("Error to list Booking Reservation.");
            }
        }

        public BookingReservation GetBookingReservationByID(int id)
        {
            try
            {
                var data = dbContext.BookingReservations.FirstOrDefault(x => x.BookingReservationId == id);
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

        public bool CreateBookingReservation(int customerId, BookingReservation bookingReservation)
        {
            bool isSuccess = false;
            try
            {
                var customerExist = dbContext.Customers.Any(x => x.CustomerId == customerId);

                if (customerExist)
                {
                    throw new InvalidOperationException($"Customer with id {customerId} does not exist.");
                }

                var count = dbContext.BookingReservations.Count();

                //Mapping the data in Customer to a NEW Customer
                var newBookingReservation = new BookingReservation
                {
                    BookingReservationId = count,
                    BookingDate = DateTime.Now,
                    CustomerId = customerId,
                    TotalPrice = 0,
                    BookingStatus = 1
                };

                var checkData = GetBookingReservationByID(bookingReservation.BookingReservationId);
                if (newBookingReservation != null)
                {
                    if (checkData == null)
                    {
                        dbContext.Add(newBookingReservation);
                        dbContext.SaveChanges();
                        isSuccess = true;
                    }
                    return isSuccess;
                }
                return isSuccess;
            }
            catch (Exception e)
            {
                throw new Exception("Error on Create" + e);
            }
        }

    }
}
