using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class BookingReservationDto
    {

        public List<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();
    }
}
