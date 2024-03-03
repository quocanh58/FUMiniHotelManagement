using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class BookingReservationDto
    {

        public List<BookingDetailAddDto> BookingDetails { get; set; } = new List<BookingDetailAddDto>();
    }
}
