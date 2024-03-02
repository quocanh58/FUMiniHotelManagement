using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using MiniHotelManagementService;
using MiniHotelManagementService.Implements;

namespace MiniHotelManagementAPI.Controllers
{
    public class BookingReservationController : Controller
    {
        private readonly IBookingReservationService _bookingReservationService;

        public BookingReservationController() => _bookingReservationService = new BookingReservationService();

        [HttpGet]
        [Route("BookingReservations")]
        public IActionResult GetBookingReservations()
        {
            try
            {
                List<BookingReservation> data = _bookingReservationService.GetAllBookingReservations();
                if (data.Count > 0)
                {
                    return Ok(data);
                }
                return Ok("List is empty.");
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [Route("BookingReservation/{id}")]
        public IActionResult GetBookingReservation(int id)
        {
            try
            {
                var data = _bookingReservationService.GetBookingReservationByID(id);
                if (data != null)
                {
                    return Ok(data);
                }
                return Ok("Connot found ID");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [Route("BookingReservation/{id}")]
        public IActionResult CreateBookingReservation(int id, [FromBody] BookingReservation bookingReservation)
        {
            bool success = false;
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                bool result = _bookingReservationService.CreateBookingReservation(id, bookingReservation);
                if (result)
                {
                    return Ok("Added booking reservation successfully.");
                }
                else
                {
                    var checkDuplicate = _bookingReservationService.GetBookingReservationByID(bookingReservation.BookingReservationId);
                    if (checkDuplicate != null)
                    {
                        return Ok("ID is already taken. Please choose a different ID.");
                    }
                    else
                    {
                        return BadRequest("Add failed");
                    }
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
