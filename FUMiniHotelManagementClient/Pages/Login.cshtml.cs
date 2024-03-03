using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FUMiniHotelManagementClient.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;
        private readonly string apiUrl = "http://localhost:5041/customers";
        private readonly IConfiguration _configuration;

        public LoginModel(ILogger<LoginModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public Customer Customer { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Email { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Password { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var adminEmail = _configuration["AdminAccount:Email"];
                var adminPassword = _configuration["AdminAccount:Password"];
                if (adminEmail == Email)
                {
                    if (adminPassword == Password)
                    {
                        HttpContext.Session.SetInt32("ROLE", 1);
                        return RedirectToPage("AdminReservation");
                    }
                    else
                    {
                        ViewData["Message"] = "Email or password incorrect!";
                    }
                }
                else
                {
                    using (var httpClient = new HttpClient())
                    {

                        string url = $"{apiUrl}?email={Email}&password={Password}";

                        using (HttpResponseMessage response = await httpClient.GetAsync(url))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                // Parse apiResponse and get customer information
                                Customer = JsonConvert.DeserializeObject<Customer>(apiResponse);
                                if (Customer.CustomerStatus == 1)
                                {
                                    HttpContext.Session.SetInt32("CUSTOMERID", Customer.CustomerId);
                                    HttpContext.Session.SetInt32("ROLE", 2);
                                    return RedirectToPage("CustomerReservation");
                                }
                                else
                                {
                                    ViewData["Message"] = "Account deleted. Please create new account.";
                                }

                            }
                            else
                            {
                                ViewData["Message"] = "Email or password incorrect!";
                            }
                        }
                    }
                }
                return Page();

            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }
    }
}
