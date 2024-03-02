using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHotelManagementRepository.Implements
{
    public interface IRoomTypeRepository
    {
        public RoomType GetRoomTypeByID(int id);
        public List<RoomType> GetAllRoomType();
        public bool DeleteRoomType(int id);
        public bool UpdateRoomType(RoomType roomType);
        public bool CreateRoomType(RoomType roomType);

    }
}
