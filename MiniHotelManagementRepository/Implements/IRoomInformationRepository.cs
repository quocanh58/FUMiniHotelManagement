using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHotelManagementRepository.Implements
{
    public interface IRoomInformationRepository
    {
        public RoomInformation GetRoomInformation(int id);
        public List<RoomInformation> GetAllRoomInformation();
    }
}
