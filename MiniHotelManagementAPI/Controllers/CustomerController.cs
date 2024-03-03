using BusinessObject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniHotelManagementService.Implements;

namespace MiniHotelManagementAPI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("customers")]
        //[Authorize]
        public IActionResult GetAllCustomer()
        {
            List<Customer> customerList = _customerService.GetAllCustomers();
            if (customerList.Count == 0)
            {
                return Ok("List is empty");
            }
            else
            {
                return Ok(customerList);
            }
        }

        [HttpGet]
        [Route("customer/{email}")]
        //[Authorize]
        public IActionResult GetCustomerByEmail(string email)
        {
            Customer customer = _customerService.GetCustomerByEmail(email);
            if (customer == null)
            {
                return Ok("Email cannot found");
            }
            else
            {
                return Ok(customer);
            }
        }

        [HttpPost]
        [Route("customer")]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                bool isSuccess = _customerService.CreateCustomer(customer);
                if (isSuccess)
                {
                    return Ok("Added customer successfully.");
                }
                else
                {
                    var checkDuplicate = _customerService.GetCustomerByEmail(customer.EmailAddress);
                    if (checkDuplicate != null)
                    {
                        return BadRequest("Email is already taken. Please choose a different email.");
                    }
                    else
                    {
                        return BadRequest("Add failed");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPatch]
        [Route("customer")]
        //[Authorize]
        public IActionResult UpdateCustomer([FromBody] Customer customer)
        {
            bool isSuccess = _customerService.UpdateCustomer(customer);
            try
            {
                if (isSuccess)
                {
                    return Ok("Update successfully.");
                }
                else
                {
                    return BadRequest("Update failed.");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error update customer " + e);
            }
        }

        [HttpDelete]
        [Route("delete-customer")]
        //[Authorize]
        public IActionResult DeleteCustomer(int id)
        {
            bool isSuccess = _customerService.DeleteCustomer(id);
            try
            {
                if (isSuccess)
                {
                    return Ok("Delete successfull.");
                }
                else
                {
                    return BadRequest("Delete failed.");
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error delete customer " + e);
            }
        }

    }
}
