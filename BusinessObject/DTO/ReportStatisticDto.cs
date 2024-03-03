using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class ReportStatisticDto
    {
        public decimal? Total { get; set; }
        public List<ReportStatisticRoomDto> rooms { get; set; }
    }
}
