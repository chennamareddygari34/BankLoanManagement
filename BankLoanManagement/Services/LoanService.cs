using AutoMapper;
using BankLoanManagement.Interfaces;
using BankLoanManagement.Models;
using BankLoanManagement.Models.DTOs;
using BankLoanManagement.Repositories;

namespace BankLoanManagement.Services
{
    public class LoanService : ILoanService
       
    {
        private readonly ILoanRepository<int, Loan> _loanRepository;
        private readonly ICustomerRepository<int, Customer> _customerRepository;

        public LoanService(ILoanRepository<int, Loan> loanRepository, ICustomerRepository<int, Customer> customerRepository)
        {
            _loanRepository = loanRepository;
            _customerRepository = customerRepository;
            
        }

        public LoanResponseDTO ApplyForLoan(LoanRequestDTO loanRequest)
        {
            var customer = _customerRepository.GetCustomerById(loanRequest.CustomerId);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }

            // Create a new loan entity
            var loan = new Loan
            {
                CustomerId = loanRequest.CustomerId,
                LoanType = loanRequest.LoanType,
                LoanDescription = loanRequest.LoanDescription,
                LoanAmount = loanRequest.LoanAmount,
                MaxLoanAmount=loanRequest.MaxLoanAmount,
                LoanTerm = loanRequest.LoanTerm,
                InterestRate = loanRequest.InterestRate,
                ApplicationDate = DateTime.Now,
                LoanStatus = "Pending",
                LoanDocumentsVerified = false
            };

            // Save the loan to the database
            var savedLoan = _loanRepository.AddLoan(loan);

            decimal monthlyInterestRate = (decimal)loan.InterestRate / 12 / 100;
            int loanTerm = loan.LoanTerm ?? 0; 
            decimal monthlyPayment = (decimal)(loan.LoanAmount * monthlyInterestRate / (1 - (decimal)Math.Pow((double)(1 + monthlyInterestRate), -loanTerm)));




            var loanResponse = new LoanResponseDTO
            {
                LoanId = savedLoan.LoanId,
                CustomerId = (int)loan.CustomerId,
                LoanType = loan.LoanType,
                LoanDescription = loan.LoanDescription,
                LoanAmount = (decimal)loan.LoanAmount,
                MaxLoanAmount = (decimal)loan.LoanAmount, 
                LoanTerm = (int)loan.LoanTerm,
                ApplicationDate = (DateTime)loan.ApplicationDate,
                InterestRate = (decimal)loan.InterestRate,
                MonthlyPayment = monthlyPayment,
                LoanStatus = loan.LoanStatus,
               

            };

            return loanResponse;
        }





        public Loan GetLoanById(int loanId)
        {
           return  _loanRepository.GetLoanById(loanId);
            
        }

        

       
    }
}
