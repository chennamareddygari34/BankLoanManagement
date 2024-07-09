using BankLoanManagement.Models;

namespace BankLoanManagement.Interfaces
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
        public Customer GetCustomerById(int CustomerId);
        public Customer AddNewCustomer(Customer customer);
        public Customer UpdateCustomer(Customer customer);
        public Customer DeleteCustomer(int id);
    }
}
