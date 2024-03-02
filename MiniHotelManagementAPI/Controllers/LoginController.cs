using BusinessObject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MiniHotelManagementRepository;
using MiniHotelManagementService.Implements;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MiniHotelManagementAPI.Controllers
{
    public class LoginController : Controller
    {
        private IConfiguration _configuration;
        private readonly ICustomerService _customerService;

        public LoginController(IConfiguration configuration, ICustomerService customerService)
        {
            _configuration = configuration;
            _customerService = customerService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] string email1, [FromBody] string password)
        {
            IActionResult response = Unauthorized();
            CustomerModel customerModel = new CustomerModel();
            customerModel.email = email1;
            customerModel.password = password;
            //check thêm password
            var user = AuthenticateUser(customerModel);
            if (customerModel != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }
            return response;

        }

        private CustomerModel AuthenticateUser(CustomerModel login)
        {
            Customer customer = _customerService.GetCustomerLogin(login.email, login.password);
            if (customer != null && customer.Password == login.password)
            {
                return new CustomerModel
                {
                    id = customer.CustomerId,
                    email = customer.EmailAddress,
                    password = customer.Password
                };
            }
            return null;
        }

        private string GenerateJSONWebToken(CustomerModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [Authorize]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
