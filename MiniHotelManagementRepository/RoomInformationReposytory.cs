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
    public class RoomInformationReposytory : IRoomInformationRepository
    {
        private RoomInformationDAO _roomInformationDAO;
        public RoomInformationReposytory() => _roomInformationDAO = new RoomInformationDAO();

        public RoomInformation GetRoomInformation(int id) => _roomInformationDAO.GetRoomInformation(id);

        public List<RoomInformation> GetAllRoomInformation() => _roomInformationDAO.GetAllRoomInformation();
    }
}
