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
    public class RoomInformationService : IRoomInformationService
    {
        private RoomInformationReposytory _roomInformationReposytory;
        public RoomInformationService() => _roomInformationReposytory = new RoomInformationReposytory();

        public List<RoomInformation> GetAllRoomInformation() => _roomInformationReposytory.GetAllRoomInformation();

        public RoomInformation GetRoomInformation(int id) => _roomInformationReposytory.GetRoomInformation(id);
    }
}
