using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiniHotelManagementRepository;
using MiniHotelManagementService.Implements;
using WebApp.Utils;

namespace MiniHotelManagementAPIClient.Pages
{
    public class CustomerModel : PageModel
    {
        public void OnGet()
        {

        }

        //private readonly ICustomerService _customerService;

        //public CustomerModel(ICustomerService customerService)
        //{
        //    _customerService = customerService;
        //}

        //[BindProperty(SupportsGet = true)]
        //public string SearchString { get; set; }

        //[BindProperty(SupportsGet = true)]
        //public string SearchField { get; set; }

        //[BindProperty(SupportsGet = true)]
        //public int? pageIndex { get; set; }

        //public PaginatedList<Customer> Customer { get; set; } = default!;

        //public async Task OnGetAsync()
        //{
        //    IQueryable<Customer> customerList = (IQueryable<Customer>)_customerService.GetAll().OrderByDescending(c => c.CustomerId);
        //    ViewData["SearchField"] = new SelectList(new List<string> { "CustomerFullName", "Telephone" });
        //    if (!String.IsNullOrEmpty(SearchString) && !String.IsNullOrEmpty(SearchField))
        //    {
        //        switch (SearchField)
        //        {
        //            case "CustomerFullName":
        //                customerList = customerList.Where(s => s.CustomerFullName.Contains(SearchString));
        //                break;
        //            case "Telephone":
        //                customerList = customerList.Where(s => s.Telephone.Contains(SearchString));
        //                break;
        //        }
        //    }

        //    var pageSize = 3;
        //    Customer = await PaginatedList<Customer>.CreateAsync(customerList.AsNoTracking(), pageIndex ?? 1, pageSize);
        //}
    }
}
