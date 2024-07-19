namespace BankLoanManagement.Models.DTOs
{
    public class LoanResponseDTO
    {
        public int LoanId { get; set; }
        public int CustomerId { get; set; }
        public string LoanType { get; set; }
        public string LoanDescription { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal MaxLoanAmount { get; set; }
        public int LoanTerm { get; set; } // in months
        public DateTime ApplicationDate { get; set; }
        public decimal InterestRate { get; set; } // Annual interest rate
        public decimal MonthlyPayment { get; set; } // Calculated monthly payment
        public string LoanStatus { get; set; }
        public DateTime? ApprovalDate { get; set; } // Nullable if not yet approved
        public int? CreditScore { get; set; } // Credit score for approval
        public bool LoanDocumentsVerified { get; set; } // Whether documents are verified
    }
}
