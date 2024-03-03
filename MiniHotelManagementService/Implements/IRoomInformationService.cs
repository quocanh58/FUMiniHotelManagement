using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHotelManagementService.Implements
{
    public interface IRoomInformationService
    {
        public RoomInformation GetRoomInformation(int id);
        public List<RoomInformation> GetAllRoomInformation();
    }
}
