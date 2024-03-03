using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class BookingDetailAddDto
    {
        public int RoomId { get; set; }
        [Required(ErrorMessage = "StartDate is required.")]
        public DateTime? StartDate { get; set; }
        [Required(ErrorMessage = "EndDate is required.")]
        public DateTime? EndDate { get; set; }
    }
}
