using BankLoanManagement.Interfaces;
using BankLoanManagement.Models;
using BankLoanManagement.Repositories;
using BankLoanManagement.Utilities;
using Microsoft.Data.SqlClient.Server;
using System.Net;

namespace BankLoanManagement.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<int,Customer> _customerRepository;
        public CustomerService(IRepository<int, Customer> customerRepository) 

        { 
          _customerRepository=customerRepository;

        }
        public Customer AddNewCustomer(Customer customer)
        {
            if (customer != null)
            {
                return _customerRepository.Add(customer);
            }
            else
            {
                throw new InvalidUserEntry();
            }
        }

        public Customer DeleteCustomer(int id)
        {
            if (id != null)
            {
                return _customerRepository.Delete(id);
            }
            else
            {
                throw new InvalidUserEntry();
            }
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetCustomerById(int customerid)
        {
           if(customerid != null)
            {
                return _customerRepository.Get(customerid);
            }
            else
            {
                throw new InvalidUserEntry();
            }
        }

        public Customer UpdateCustomer(Customer customer)
        {
            var mycustomer = _customerRepository.Get(customer.CustomerId);
            if (mycustomer != null)
            {
                mycustomer.MaritalStatus = customer.MaritalStatus;
                mycustomer.OccupationType = customer.OccupationType;
                mycustomer.PhoneNumber = customer.PhoneNumber;
                mycustomer.City = customer.City;
                mycustomer.State = customer.State;
                mycustomer.District = customer.District;
                mycustomer.HouseNo = customer.HouseNo;
                mycustomer.Landmark = customer.Landmark;
                mycustomer.Pincode = customer.Pincode;
                return _customerRepository.Update(mycustomer);
            }
            else
            {
                throw new InvalidAddressException();
            }

        }
    }
}
