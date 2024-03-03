using BusinessObject.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FUMiniHotelManagementClient.Pages
{
    public class AdminReservationModel : PageModel
    {
        private readonly ILogger<AdminReservationModel> _logger;
        private readonly string apiUrl = "http://localhost:5041/BookingReservations";

        public AdminReservationModel(ILogger<AdminReservationModel> logger)
        {
            _logger = logger;
        }

        [BindProperty(SupportsGet = true)]
        public string startDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public string endDate { get; set; }

        public List<BookingReservationResponseDto> BookingReservations { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            int? role = HttpContext.Session.GetInt32("ROLE");
            if (role == 1)
            {
                using (var httpClient = new HttpClient())
                {
                    // Append the search parameter to the API URL if a name is provided
                    string url = string.IsNullOrEmpty(startDate) || string.IsNullOrEmpty(endDate)
                ? apiUrl
                : $"{apiUrl}?startDate={Uri.EscapeDataString(startDate)}&endDate={Uri.EscapeDataString(endDate)}";


                    using (HttpResponseMessage response = await httpClient.GetAsync(url))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        BookingReservations = JsonConvert.DeserializeObject<List<BookingReservationResponseDto>>(apiResponse);
                    }
                }
            }
            else
            {
                ViewData["Message"] = "dont can access this function";
            }


            return Page();
        }
    }
}
