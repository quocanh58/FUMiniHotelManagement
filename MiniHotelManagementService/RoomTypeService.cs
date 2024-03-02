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
    public class RoomTypeService : IRoomTypeService
    {
        private RoomTypeRepository _roomTypeRepository;
        public RoomTypeService() => _roomTypeRepository = new RoomTypeRepository();

        public bool CreateRoomType(RoomType roomType) => _roomTypeRepository.CreateRoomType(roomType);

        public bool DeleteRoomType(int id) => _roomTypeRepository.DeleteRoomType(id);

        public List<RoomType> GetAllRoomType() => _roomTypeRepository.GetAllRoomType();

        public RoomType GetRoomTypeByID(int id) => _roomTypeRepository.GetRoomTypeByID(id);

        public bool UpdateRoomType(RoomType roomType) => _roomTypeRepository.UpdateRoomType(roomType);
    }
}
