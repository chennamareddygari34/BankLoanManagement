using BankLoanManagement.Interfaces;
using BankLoanManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BankLoanManagement.Repositories
{
    public class LoanRepository : ILoanRepository<int, Loan>
    {
        private  readonly BankLoanApplicationContext _context;
        public LoanRepository(BankLoanApplicationContext context) 
        {
            _context = context;
        }

        public Loan AddLoan(Loan loan)
        {
            _context.Loans.Add(loan);
            _context.SaveChanges();
            return loan;
        }

        public Loan DeleteLoan(int loanId)
        {
            var loan = _context.Loans.Find(loanId);
            if (loan != null)
            {
                _context.Loans.Remove(loan);
                _context.SaveChanges();

            }
            return loan;

        }

        public Customer GetCustomerById(int customerId)
        {
            return _context.Customers.Find(customerId);
        }
        public Loan GetLoanById(int loanId)
        {
            var loan= _context.Loans.FirstOrDefault(l=>l.LoanId==loanId);
            return loan;
        }

       

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Loan UpdateLoan(Loan loan)
        {
            _context.Entry<Loan>(loan).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return loan;
        }
    }
}
