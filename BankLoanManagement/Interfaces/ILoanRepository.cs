using BankLoanManagement.Models;

namespace BankLoanManagement.Interfaces
{
    public interface ILoanRepository<K, T> where T : class
    {
        public Loan AddLoan(Loan loan);
        public Loan GetLoanById(int loanId);
        public Customer GetCustomerById(int customerId);
        public Loan UpdateLoan(Loan loan);
        public Loan DeleteLoan(int loanId);
        void SaveChanges();

    }
}
