using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHotelManagementDAO
{
    public class RoomInformationDAO
    {
        public static RoomInformationDAO instance = null;
        public static FuminiHotelManagementContext dbContext = null;

        public RoomInformationDAO()
        {
            dbContext = new FuminiHotelManagementContext();
        }
        public static RoomInformationDAO Instance()
        {
            if (instance == null)
            {
                instance = new RoomInformationDAO();
            }
            return instance;
        }

        public List<RoomInformation> GetAllRoomInformation()
        {
            try
            {
                var data = dbContext.RoomInformations.ToList();
                return data;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public RoomInformation GetRoomInformation(int id)
        {
            try
            {
                var data = dbContext.RoomInformations.Find(id);
                if (data != null)
                {
                    return data;
                }
                return null;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

    }
}
