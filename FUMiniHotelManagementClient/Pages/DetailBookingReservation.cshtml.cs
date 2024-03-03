using BusinessObject.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FUMiniHotelManagementClient.Pages
{
    public class DetailBookingReservationModel : PageModel
    {

        private readonly ILogger<DetailBookingReservationModel> _logger;
        private readonly string apiUrl = "https://localhost:44311/api/BookingReservation/GetReservationDetail";

        public DetailBookingReservationModel(ILogger<DetailBookingReservationModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public BookingReservationDetailDto BookingReservationDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(int reservationId)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    // Append the search parameter to the API URL if a name is provided
                    string url = $"{apiUrl}/{reservationId}";

                    using (HttpResponseMessage response = await httpClient.GetAsync(url))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        BookingReservationDetail = JsonConvert.DeserializeObject<BookingReservationDetailDto>(apiResponse);
                    }
                }

                return Page();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occurred during the API request
                _logger.LogError($"An error occurred: {ex.Message}");
            }

            // If there was an error, return an error page
            return BadRequest("Failed to retrieve booking reservation details.");
        }

    }
}
