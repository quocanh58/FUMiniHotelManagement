using BusinessObject.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHotelManagementDAO
{
    public class CustomerDAO
    {
        public static CustomerDAO instance = null;
        public static FuminiHotelManagementContext dbContext = null;

        public CustomerDAO()
        {
            dbContext = new FuminiHotelManagementContext();
        }

        public static CustomerDAO Intance()
        {
            if (instance == null)
            {
                instance = new CustomerDAO();
            }
            return instance;
        }

        public bool Login(string email, string password)
        {
            bool isSuccess = false;
            try
            {
                var checkLogin = dbContext.Customers.FirstOrDefault(x => x.EmailAddress.Equals(email) && x.Password.Equals(password));
                if (checkLogin != null)
                {
                    isSuccess = true;
                }
                return isSuccess;
            }
            catch (Exception e)
            {
                throw new Exception("Erorr login customer " + e);
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            return dbContext.Customers.ToList();
        }

        public List<Customer> GetAllCustomers()
        {
            try
            {
                return dbContext.Customers.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Customer GetCustomerByEmail(string email)
        {
            try
            {
                var check = dbContext.Customers.FirstOrDefault(x => x.EmailAddress.Equals(email));
                if (check != null)
                {
                    return check;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Customer GetCustomerByID(int id)
        {
            try
            {
                var check = dbContext.Customers.FirstOrDefault(x => x.CustomerId == id);
                if (check != null)
                {
                    return check;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Customer GetCustomerLogin(string email, string password)
        {
            try
            {
                var check = dbContext.Customers.FirstOrDefault(x => x.EmailAddress.Equals(email) && x.Password.Equals(password));
                if (check != null)
                {
                    return check;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool CreateCustomer(Customer customer)
        {
            bool isSuccess = false;
            try
            {
                var data = GetCustomerByEmail(customer.EmailAddress);
                if (customer != null)
                {
                    if (data == null)
                    {
                        dbContext.Customers.Add(customer);
                        dbContext.SaveChanges();
                        isSuccess = true;
                    }
                    return isSuccess;
                }
                return isSuccess;
            }
            catch (Exception e)
            {
                throw new Exception("Error create customer" + e);
            }
        }

        public bool DeleteCustomer(int id)
        {
            bool isSuccess = false;
            try
            {
                var check = dbContext.Customers.Find(id);
                if (check != null)
                {
                    dbContext.Customers.Remove(check);
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
            catch (Exception e)
            {
                throw new Exception("Error delete customer" + e);
            }
        }

        public bool UpdateCustomer(Customer customer)
        {
            bool isSuccess = false;
            try
            {
                if (customer != null)
                {
                    dbContext.Customers.Update(customer);
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
            catch (Exception e)
            {
                throw new Exception("Error update customer" + e);
            }
        }

    }
}
