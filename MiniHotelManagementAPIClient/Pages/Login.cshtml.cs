using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniHotelManagementAPIClient.ViewModel;
using MiniHotelManagementService;
using MiniHotelManagementService.Implements;

namespace MiniHotelManagementAPIClient.Pages
{
    public class LoginModel : PageModel
    {

        const string KEY_SESSION_ADMIN = "ADMIN";
        const string KEY_SESSION_USER = "USERS";
        const string KEY_SESSION_MANAGER = "MANAGERS";

        private readonly ICustomerService _customerService;

        public LoginModel()
        {
            _customerService = new CustomerService();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public LoginVM LoginVM { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var customer = _customerService.GetAllCustomers().FirstOrDefault(x => x.EmailAddress.Equals(LoginVM.Email)
                                                                               && x.Password.Equals(LoginVM.Password)
                                                                               && x.Role == 1);
            if (customer == null)
            {
                ModelState.AddModelError("LoginVM.Password", "You do not have permission to do this function!");
                return Page();
            }

            return RedirectToPage("/Customer");

        }
    }
}
