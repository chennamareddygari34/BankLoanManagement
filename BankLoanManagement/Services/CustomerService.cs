using BankLoanManagement.Interfaces;
using BankLoanManagement.Models;
using BankLoanManagement.Models.DTOs;
using BankLoanManagement.Utilities;
using System.Collections.Generic;
using System.Net;

namespace BankLoanManagement.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository<int, Customer> _customerRepository;

        public CustomerService(ICustomerRepository<int, Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<CustomerDTO> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomer();
        }
    

    public Customer DeleteCustomerById(int customerId)
        {
            return _customerRepository.DeleteCustomerById(customerId);
        }



        public CustomerDTO GetCustomerById(int customerId)
        {
            return _customerRepository.GetCustomerById(customerId);
        }

        public CustomerDTO UpdateCustomer(CustomerDTO customerdto)
        {
            return _customerRepository.UpdateCustomer(customerdto);
        }

        public CustomerDTO AddCustomer(CustomerDTO customerDTO)
        {
            return _customerRepository.AddCustomer(customerDTO);
        }
    }
}
