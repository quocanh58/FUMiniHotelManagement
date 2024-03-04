using BusinessObject.DTO;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniHotelManagementDAO;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace FUMiniHotelManagementClient.Pages
{
    public class CustomerReservationModel : PageModel
    {
        private readonly ILogger<CustomerReservationModel> _logger;
        private readonly string apiUrl = "https://localhost:44311/api/BookingReservation/GetReservationsByCustomer";
        private readonly string apiRoomUrl = "https://localhost:44311/api/RoomInformation";
        private readonly string apiCheck = "https://localhost:44311/api/BookingDetail";
        private readonly string apiCreate = "https://localhost:44311/api/BookingReservation/Create";
        private readonly string apiCreateList = "https://localhost:44311/api/BookingDetail";
        private readonly string apiGetList = "https://localhost:44311/api/BookingDetail/bookingdetails";
        private readonly string apiDeleteList = "https://localhost:44311/api/BookingDetail";
        private readonly string apiClearList = "https://localhost:44311/api/BookingDetail/clear";

        public CustomerReservationModel(ILogger<CustomerReservationModel> logger)
        {
            _logger = logger;
        }

        [BindProperty(SupportsGet = true)]
        public string startDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public string endDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public int RoomId { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Status { get; set; }

        public List<RoomInformation> RoomInformations { get; set; }

        public List<BookingReservation> BookingReservations { get; set; }

        public List<BookingDetail> BookingDetails { get; set; }

        public BookingReservationDto BookingReservationDto { get; set; }

        [TempData]
        public string BookingReservationDtoJson { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            int? id = HttpContext.Session.GetInt32("CUSTOMERID");
            int? role = HttpContext.Session.GetInt32("ROLE");
            if (role == 2)
            {
                using (var httpClient = new HttpClient())
                {
                    // Append the search parameter to the API URL if a name is provided
                    string url = string.IsNullOrEmpty(startDate) || string.IsNullOrEmpty(endDate)
                ? $"{apiUrl}?customerId={id}"
                : $"{apiUrl}?customerId={id}&startDate={Uri.EscapeDataString(startDate)}&endDate={Uri.EscapeDataString(endDate)}";


                    using (HttpResponseMessage response = await httpClient.GetAsync(url))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        BookingReservations = JsonConvert.DeserializeObject<List<BookingReservation>>(apiResponse);
                        await LoadRoomAsync();
                    }
                }
            }
            else
            {
                ViewData["Message"] = "You are not allowed to access this function!";
            }


            return Page();
        }

        private async Task LoadRoomAsync()
        {
            using (var httpClient = new HttpClient())
            {
                // Append the search parameter to the API URL if a name is provided
                string url = apiRoomUrl;

                using (HttpResponseMessage response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    RoomInformations = JsonConvert.DeserializeObject<List<RoomInformation>>(apiResponse);
                    await LoadRoomAddAsync();
                }
            }
        }

        private async Task LoadRoomAddAsync()
        {
            using (var httpClient = new HttpClient())
            {
                // Append the search parameter to the API URL if a name is provided
                string url = apiGetList;

                using (HttpResponseMessage response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    BookingDetails = JsonConvert.DeserializeObject<List<BookingDetail>>(apiResponse);
                }
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                bool check;

                using (var httpClient = new HttpClient())
                {
                    string url = $"{apiCheck}?roomId={RoomId}&start={StartDate}&end={EndDate}";

                    using (HttpResponseMessage response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            check = JsonConvert.DeserializeObject<bool>(apiResponse);
                        }
                        else if (response.StatusCode == HttpStatusCode.BadRequest)
                        {
                            ViewData["ErrorMessage"] = "Invalid data. Please check the input.";
                            await OnGetAsync();
                            return RedirectToPage();
                        }
                        else
                        {
                            ViewData["ErrorMessage"] = $"Error: {response.StatusCode}";
                            await OnGetAsync();
                            return RedirectToPage("./CustomerReservation");
                        }
                    }
                }

                if (check)
                {
                    ViewData["ErrorMessage"] = "The selected dates are not available.";
                    return Page();
                }
                else
                {
                    BookingDetailAddDto bookingDetail = new BookingDetailAddDto
                    {
                        RoomId = RoomId,
                        StartDate = StartDate,
                        EndDate = EndDate,
                    };

                    using (var httpClient = new HttpClient())
                    {
                        string createBookingDetailUrl = apiCreateList;

                        string bookingDetailJson = JsonConvert.SerializeObject(bookingDetail);
                        StringContent content = new StringContent(bookingDetailJson, Encoding.UTF8, "application/json");

                        using (HttpResponseMessage response = await httpClient.PostAsync(createBookingDetailUrl, content))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                ViewData["SuccessMessage"] = "Room added successfully.";
                                return RedirectToPage();
                            }
                            else
                            {
                                ViewData["ErrorMessage"] = "Failed to add room. Please try again.";
                                await OnGetAsync();
                                return RedirectToPage("./CustomerReservation");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = $"An error occurred: {ex.Message}";
                return Page();
            }
        }

        public async Task<IActionResult> OnPostCustomHandlerAsync()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    // Append the search parameter to the API URL if a name is provided
                    string url = apiGetList;

                    using (HttpResponseMessage response = await httpClient.GetAsync(url))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        BookingDetails = JsonConvert.DeserializeObject<List<BookingDetail>>(apiResponse);
                    }
                }

                BookingReservationDto = new BookingReservationDto();
                BookingReservationDto.BookingDetails = BookingDetails;
                if (BookingReservationDto != null)
                {
                    int? id = HttpContext.Session.GetInt32("CUSTOMERID");
                    using (var httpClient = new HttpClient())
                    {

                        var response = await httpClient.PostAsJsonAsync($"{apiCreate}/{id}", BookingReservationDto);


                        if (response.IsSuccessStatusCode)
                        {
                            var clearListResponse = await httpClient.DeleteAsync(apiClearList);
                            if (clearListResponse.IsSuccessStatusCode)
                            {
                                await OnGetAsync();
                            }
                        }
                        else
                        {
                            string errorMessage = await response.Content.ReadAsStringAsync();
                            return BadRequest($"Failed to create room information: {errorMessage}");
                        }
                    }
                }
                else
                {
                    ViewData["ErrorMessage"] = "BookingDetails is null or empty.";
                    return Page();
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int roomId)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.DeleteAsync($"{apiDeleteList}/{roomId}");

                    if (response.IsSuccessStatusCode)
                    {
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

public static class SessionExtensions
{
    public static void SetObject(this ISession session, string key, object value)
    {
        session.SetString(key, JsonConvert.SerializeObject(value));
    }

    public static T GetObject<T>(this ISession session, string key)
    {
        var value = session.GetString(key);
        return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
    }
}
