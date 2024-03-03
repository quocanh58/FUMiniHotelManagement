using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{

    public class CustomerUpdateDto
    {

        [Required(ErrorMessage = "This field is Required!")]
        [MinLength(10, ErrorMessage = "Name Must be larger than 10 characters")]
        [MaxLength(25, ErrorMessage = "Name cannot be over 25 characters")]
        public string CustomerFullName { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        [Telephone(ErrorMessage = "Telephone must be 10 digits")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        [EmailAddress(ErrorMessage = "Invalid Email Address format")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        [NotFutureDate(ErrorMessage = "Invalid date format. Use YYYY-MM-DD")]
        public DateTime? CustomerBirthday { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        public byte? CustomerStatus { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        public string Password { get; set; }
    }
}
