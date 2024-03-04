using System.ComponentModel.DataAnnotations;

namespace MiniHotelManagementAPIClient.ViewModel
{
    public class LoginVM
    {
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
