namespace BankLoanManagement.Models.DTOs
{
    public class LoanRequestDTO
    {
        public int CustomerId { get; set; }
        public string LoanType { get; set; }
        public string LoanDescription { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal? MaxLoanAmount { get; set; }
        public int LoanTerm { get; set; } // in months
        public decimal InterestRate { get; set; } // Annual interest rate
    }
}


 
