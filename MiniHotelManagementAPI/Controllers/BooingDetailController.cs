using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using MiniHotelManagementRepository;
using MiniHotelManagementService.Implements;

namespace MiniHotelManagementAPI.Controllers
{
    public class BooingDetailController : Controller
    {
        private readonly IBookingDetailService _bookingDetailService;
        public BooingDetailController(IBookingDetailService bookingDetailService) => _bookingDetailService = bookingDetailService;

        [HttpGet]
        [Route("bookingDetails")]
        public IActionResult GetAllBookingDetails()
        {
            try
            {
                List<BookingDetail> data = _bookingDetailService.GetAllBookingDetails();
                if (data.Count > 0)
                {
                    return Ok(data);
                }
                else
                {
                    return Ok("List is empty");
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [Route("bookingDetailByRoom/{roomID}")]
        public IActionResult GetByRoomID(int roomID)
        {
            try
            {
                var data = _bookingDetailService.GetBookingDetailByRoomID(roomID);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return Ok("Cannot found ID");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [Route("bookingDetailByReservation/{bookingReservationID}")]
        public IActionResult GetByBookingReservationID(int bookingReservationID)
        {
            try
            {
                var data = _bookingDetailService.GetBookingDetailByBookingReservationID(bookingReservationID);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return Ok("Cannot found ID");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }

}
