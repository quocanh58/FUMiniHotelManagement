using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class RoomInformationViewDto
    {
        public int RoomId { get; set; }
        [Required(ErrorMessage = "Room Number is required.")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Room Number must be exactly 5 characters.")]
        public string RoomNumber { get; set; }
        public string RoomDetailDescription { get; set; }
        [Required(ErrorMessage = "Room Max Capacity is required.")]
        [Range(1, 10, ErrorMessage = "Room Max Capacity must be between 1 and 10.")]
        public int? RoomMaxCapacity { get; set; }
        public int RoomTypeId { get; set; }
        public byte? RoomStatus { get; set; }
        [Required(ErrorMessage = "Room Price Per Day is required.")]
        [Range(100, 10000, ErrorMessage = "Room Price Per Day must be between 100 and 10000.")]
        public decimal? RoomPricePerDay { get; set; }
        public string RoomTypeName { get; set; }
        public string TypeDescription { get; set; }
        public string TypeNote { get; set; }
    }
}
