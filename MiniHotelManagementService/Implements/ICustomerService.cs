using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHotelManagementService.Implements
{
    public interface ICustomerService
    {
        public bool Login(string email, string password);
        public List<Customer> GetAllCustomers();
        public Customer GetCustomerByEmail(string email);
        public Customer GetCustomerLogin(string email, string password);
        public bool UpdateCustomer(Customer customer);
        public bool DeleteCustomer(int id);
        public bool CreateCustomer(Customer customer);

    }
}
