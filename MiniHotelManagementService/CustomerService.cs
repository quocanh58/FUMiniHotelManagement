using BusinessObject.Models;
using MiniHotelManagementRepository;
using MiniHotelManagementService.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHotelManagementService
{
    public class CustomerService : ICustomerService
    {
        private CustomerRepository _customerRepository;
        public CustomerService() => _customerRepository = new CustomerRepository();

        public bool CreateCustomer(Customer customer) => _customerRepository.CreateCustomer(customer);

        public bool DeleteCustomer(int id) => _customerRepository.DeleteCustomer(id);

        public IEnumerable<Customer> GetAll() => _customerRepository.GetAll();

        public List<Customer> GetAllCustomers() => _customerRepository.GetAllCustomers();

        public Customer GetCustomerByEmail(string email) => _customerRepository.GetCustomerByEmail(email);

        public Customer GetCustomerByID(int id) => _customerRepository.GetCustomerByID(id);

        public Customer GetCustomerLogin(string email, string password) => _customerRepository.GetCustomerLogin(email, password);

        public bool Login(string email, string password) => _customerRepository.Login(email, password);

        public bool UpdateCustomer(Customer customer) => _customerRepository.UpdateCustomer(customer);
    }
}
