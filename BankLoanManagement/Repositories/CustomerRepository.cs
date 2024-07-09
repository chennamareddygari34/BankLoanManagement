using BankLoanManagement.Interfaces;
using BankLoanManagement.Models;

namespace BankLoanManagement.Repositories
{
    public class CustomerRepository : IRepository<int, Customer>
    {
        private readonly BankLoanApplicationContext _context;
        public CustomerRepository(BankLoanApplicationContext context) 
        { 
            _context = context;
        }

        public Customer Add(Customer item)
        {
            _context.Customers.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Customer Delete(int key)
        {
            var customers = Get(key);
            if (customers != null)
            {
                _context.Customers.Remove(customers);
                _context.SaveChanges();
                return customers;
            }
            return null;
        }

        public Customer Get(int key)
        {
            var customer = _context.Customers.FirstOrDefault(c=> c.CustomerId == key);
            if (customer != null)
            {
                return customer;
            }
            return null;
        }

        public List<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer Update(Customer item)
        {
            _context.Entry<Customer>(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return item;

        
        }
    }
}
