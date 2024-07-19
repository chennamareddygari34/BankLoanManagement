using BankLoanManagement.Models;
using BankLoanManagement.Models.DTOs;

namespace BankLoanManagement.Interfaces
{
    public interface ILoanService
    {
        public LoanResponseDTO ApplyForLoan(LoanRequestDTO loanRequest);
        public Loan GetLoanById(int loanId);
    }
}
