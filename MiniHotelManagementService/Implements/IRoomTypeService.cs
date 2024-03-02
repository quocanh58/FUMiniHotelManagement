using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHotelManagementService.Implements
{
    public interface IRoomTypeService
    {
        public RoomType GetRoomTypeByID(int id);
        public List<RoomType> GetAllRoomType();
        public bool DeleteRoomType(int id);
        public bool UpdateRoomType(RoomType roomType);
        public bool CreateRoomType(RoomType roomType);
    }
}
