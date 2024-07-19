using BankLoanManagement.Models;
using BankLoanManagement.Models.DTOs;

namespace BankLoanManagement.Interfaces
{
    public interface ICustomerService
    {
        public List<CustomerDTO> GetAllCustomers();
        public CustomerDTO GetCustomerById(int customerId);
        CustomerDTO AddCustomer(CustomerDTO customerDTO);
        public CustomerDTO UpdateCustomer(CustomerDTO customerdto);
        public Customer DeleteCustomerById(int CustomerId);
    }
}
