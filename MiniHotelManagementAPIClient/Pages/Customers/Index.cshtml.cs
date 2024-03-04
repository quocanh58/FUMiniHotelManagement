using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Utils;
using MiniHotelManagementService.Implements;

namespace MiniHotelManagementAPIClient.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public IndexModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchField { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? pageIndex { get; set; }

        public PaginatedList<Customer> Customer { get; set; } = default!;

        public async Task OnGetAsync()
        {
            IQueryable<Customer> customerList = (IQueryable<Customer>)_customerService.GetAll().OrderByDescending(c => c.CustomerId);
            ViewData["SearchField"] = new SelectList(new List<string> { "CustomerFullName", "Telephone" });
            if (!String.IsNullOrEmpty(SearchString) && !String.IsNullOrEmpty(SearchField))
            {
                switch (SearchField)
                {
                    case "CustomerFullName":
                        customerList = customerList.Where(s => s.CustomerFullName.Contains(SearchString));
                        break;
                    case "Telephone":
                        customerList = customerList.Where(s => s.Telephone.Contains(SearchString));
                        break;
                }
            }

            var pageSize = 3;
            Customer = await PaginatedList<Customer>.CreateAsync(customerList.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
