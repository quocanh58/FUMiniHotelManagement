using BusinessObject.Models;
using MiniHotelManagementDAO;
using MiniHotelManagementRepository.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHotelManagementRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        private CustomerDAO _customerDAO;

        public CustomerRepository() => _customerDAO = new CustomerDAO();

        public bool CreateCustomer(Customer customer) => _customerDAO.CreateCustomer(customer);

        public bool DeleteCustomer(int id) => _customerDAO.DeleteCustomer(id);

        public List<Customer> GetAllCustomers() => _customerDAO.GetAllCustomers();

        public Customer GetCustomerByEmail(string email) => _customerDAO.GetCustomerByEmail(email);

        public Customer GetCustomerLogin(string email, string password) => _customerDAO.GetCustomerLogin(email, password);

        public bool Login(string email, string password) => _customerDAO.Login(email, password);

        public bool UpdateCustomer(Customer customer) => _customerDAO.UpdateCustomer(customer);
    }
}
