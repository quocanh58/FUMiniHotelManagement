using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHotelManagementDAO
{
    public class RoomTypeDAO
    {
        public static RoomTypeDAO instance = null;
        public static FuminiHotelManagementContext dbContext = null;
        public RoomTypeDAO()
        {
            dbContext = new FuminiHotelManagementContext();
        }
        private static RoomTypeDAO Instance()
        {
            if (instance == null)
            {
                instance = new RoomTypeDAO();
            }
            return instance;
        }

        public List<RoomType> GetAllRoomType()
        {
            try
            {
                return dbContext.RoomTypes.ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public RoomType GetRoomTypeByID(int id)
        {
            try
            {
                var data = dbContext.RoomTypes.FirstOrDefault(x => x.RoomTypeId == id);
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

        public bool CreateRoomType(RoomType roomType)
        {
            bool isSuccess = false;
            try
            {
                var data = GetRoomTypeByID(roomType.RoomTypeId);
                if (roomType != null)
                {
                    if (data == null)
                    {
                        dbContext.Add(roomType);
                        dbContext.SaveChanges();
                        isSuccess = true;
                    }
                    return isSuccess;
                }
                return isSuccess;
            }
            catch (Exception e)
            {
                throw new Exception("Error in added room type " + e);
            }
        }

        public bool UpdateRoomType(RoomType roomType)
        {
            bool isSuccess = false;
            try
            {
                if (roomType != null)
                {
                    dbContext.Update(roomType);
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool DeleteRoomType(int id)
        {
            bool isSuccess = false;
            try
            {
                var data = dbContext.RoomTypes.Find(id);
                if (data != null)
                {
                    dbContext.RoomTypes.Remove(data);
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
