using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class BookingReservationDetailDto
    {
        public int BookingReservationId { get; set; }
        public DateTime? BookingDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public byte? BookingStatus { get; set; }

        public virtual CustomerViewDetail Customer { get; set; }
        public virtual List<BookingDetailView> BookingDetail { get; set; }
    }
}
