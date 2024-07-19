using BankLoanManagement.Models;
using BankLoanManagement.Models.DTOs;

namespace BankLoanManagement.Interfaces
{
    public interface ICustomerRepository<K, T> where T : class
    {
        public List<CustomerDTO> GetAllCustomer();
        CustomerDTO GetCustomerById(int customerId);
        public CustomerDTO AddCustomer(CustomerDTO customerDTO);
                    
        public Customer DeleteCustomerById(int CustomerId);
        public CustomerDTO UpdateCustomer(CustomerDTO customerDTO);
       
    }
}
