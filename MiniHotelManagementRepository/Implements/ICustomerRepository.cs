using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHotelManagementRepository.Implements
{
    public interface ICustomerRepository
    {
        public bool Login(string email, string password);
        public List<Customer> GetAllCustomers();
        public Customer GetCustomerByEmail(string email);
        public Customer GetCustomerLogin(string email, string password);
        public bool UpdateCustomer(Customer customer);
        public bool DeleteCustomer(int id);
        public bool CreateCustomer(Customer customer);
        public IEnumerable<Customer> GetAll();
        public Customer GetCustomerByID(int id);
    }
}
