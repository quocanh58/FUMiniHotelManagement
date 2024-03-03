using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using MiniHotelManagementRepository;
using MiniHotelManagementService.Implements;

namespace MiniHotelManagementAPI.Controllers
{
    public class RoomInformationController : Controller
    {
        private readonly IRoomInformationService _informationService;

        public RoomInformationController(IRoomInformationService roomInformationService) => _informationService = roomInformationService;

        [HttpGet]
        [Route("RoomInfomations")]
        public IActionResult GetRoomInfomations()
        {
            try
            {
                List<RoomInformation> data = _informationService.GetAllRoomInformation();
                if (data.Count > 0)
                {
                    return Ok(data);
                }
                else
                {
                    return Ok("List is empty.");
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [Route("RoomInfomation{id}")]
        public IActionResult GetRoomInfomation(int id)
        {
            try
            {
                var data = _informationService.GetRoomInformation(id);
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
