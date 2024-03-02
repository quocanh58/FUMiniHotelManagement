using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using MiniHotelManagementService.Implements;

namespace MiniHotelManagementAPI.Controllers
{
    public class RoomTypeController : Controller
    {
        private readonly IRoomTypeService _roomTypeService;
        public RoomTypeController(IRoomTypeService roomTypeService) => _roomTypeService = roomTypeService;

        [HttpGet]
        [Route("RoomTypes")]
        public IActionResult GetAllRoomType()
        {
            try
            {
                List<RoomType> data = _roomTypeService.GetAllRoomType();
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
        [Route("RoomTypes{id}")]
        public IActionResult GetRoomTypeByID(int id)
        {
            try
            {
                var data = _roomTypeService.GetRoomTypeByID(id);
                if (data != null)
                {
                    return Ok(data);
                }
                return Ok("Cannot found ID room type");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        [Route("RoomType")]
        public IActionResult AddRoomType([FromBody] RoomType roomType)
        {
            try
            {
                var isSuccess = _roomTypeService.CreateRoomType(roomType);
                if (isSuccess)
                {
                    return Ok("Added room type successfull");
                }
                else
                {
                    var check = GetRoomTypeByID(roomType.RoomTypeId);
                    if (check != null)
                    {
                        return Ok("ID already in list..");
                    }
                    else
                    {
                        return BadRequest("Add room type failed");
                    }
                }
            }
            catch (Exception e)
            {

                throw new Exception("Add room type error.");
            }
        }

        [HttpDelete]
        [Route("RoomType{id}")]
        public IActionResult DeleteRoomType(int id)
        {
            var isSucces = _roomTypeService.DeleteRoomType(id);
            try
            {
                if (isSucces)
                {
                    return Ok("Delete successfully.");
                }
                else
                {
                    return NotFound("Delete failed.");
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpPatch]
        [Route("RoomType")]
        public IActionResult UpdateRoomtype([FromBody] RoomType roomType)
        {
            bool isSuccess = _roomTypeService.UpdateRoomType(roomType);
            try
            {
                var checkIdExist = GetRoomTypeByID(roomType.RoomTypeId);
                if (checkIdExist == null)
                {
                    return Ok("Id not found.");
                }

                if (isSuccess)
                {
                    return Ok("Updated successfully.");
                }
                else
                {
                    return Ok("Updated failed.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
