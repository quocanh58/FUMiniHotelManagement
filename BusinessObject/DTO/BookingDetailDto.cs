using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class DateRangeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var bookingDetail = (BookingDetailDto)validationContext.ObjectInstance;

            if (bookingDetail.StartDate.HasValue && bookingDetail.EndDate.HasValue &&
                bookingDetail.StartDate.Value.Date <= bookingDetail.EndDate.Value.Date &&
                bookingDetail.StartDate.Value.Date >= DateTime.Now.Date &&
                bookingDetail.EndDate.Value.Date >= bookingDetail.StartDate.Value.Date)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Invalid date range.");
        }
    }

    public class BookingDetailDto
    {
        [Required(ErrorMessage = "StartDate is required.")]
        [DateRange(ErrorMessage = "Invalid date range.")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "EndDate is required.")]
        [DateRange(ErrorMessage = "Invalid date range.")]
        public DateTime? EndDate { get; set; }
    }
}
