using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FUMiniHotelManagementClient.Pages
{
    public class CustomerInformationModel : PageModel
    {
        private readonly ILogger<CustomerInformationModel> _logger;
        private readonly string apiUrl = "https://localhost:5041/customers";
        private readonly string deleteApiUrl = "https://localhost:5041/delete-customer"; // Update with your actual API endpoint

        public CustomerInformationModel(ILogger<CustomerInformationModel> logger)
        {
            _logger = logger;
        }

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        public List<Customer> Customers { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            int? role = HttpContext.Session.GetInt32("ROLE");
            if (role == 1)
            {
                using (var httpClient = new HttpClient())
                {
                    // Append the search parameter to the API URL if a name is provided
                    string url = string.IsNullOrEmpty(Name) ? apiUrl : $"{apiUrl}?name={Name}";

                    using (HttpResponseMessage response = await httpClient.GetAsync(url))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Customers = JsonConvert.DeserializeObject<List<Customer>>(apiResponse);
                    }
                }

            }
            else
            {
                ViewData["Message"] = "dont can access this function";
            }


            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int customerId)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    // Send a DELETE request to the API to delete the customer
                    HttpResponseMessage response = await httpClient.DeleteAsync($"{deleteApiUrl}/{customerId}");

                    if (response.IsSuccessStatusCode)
                    {
                        // Reload the page after successful deletion
                        return RedirectToPage();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        return BadRequest($"Failed to delete customer: {errorMessage}");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }
    }
}
