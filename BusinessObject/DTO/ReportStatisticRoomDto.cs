using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class ReportStatisticRoomDto
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public string RoomDetailDescription { get; set; }
        public int? RoomMaxCapacity { get; set; }
        public string TypeName { get; set; }
        public decimal? RoomPricePerDay { get; set; }
        public decimal? TotalPriceRoom { get; set; }
        public int? TotalDaysRoom { get; set; }
    }
}
