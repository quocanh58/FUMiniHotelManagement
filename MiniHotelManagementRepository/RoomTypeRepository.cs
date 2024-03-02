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
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private RoomTypeDAO _roomTypeDAO;
        public RoomTypeRepository() => _roomTypeDAO = new RoomTypeDAO();

        public bool CreateRoomType(RoomType roomType) => _roomTypeDAO.CreateRoomType(roomType);

        public bool DeleteRoomType(int id) => _roomTypeDAO.DeleteRoomType(id);

        public List<RoomType> GetAllRoomType() => _roomTypeDAO.GetAllRoomType();

        public RoomType GetRoomTypeByID(int id) => _roomTypeDAO.GetRoomTypeByID(id);

        public bool UpdateRoomType(RoomType roomType) => _roomTypeDAO.UpdateRoomType(roomType);
    }
}
