using System;
using System.Collections.Generic;

namespace BankLoanManagement.Models
{
    public partial class Loan
    {
        public int LoanId { get; set; }
        public int? CustomerId { get; set; }
        public string? LoanType { get; set; }
        public string? LoanDescription { get; set; }
        public decimal? LoanAmount { get; set; }
        public decimal? MaxLoanAmount { get; set; }
        public int? LoanTerm { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public decimal? InterestRate { get; set; }
        public decimal? MonthlyPayment { get; set; }
        public string? LoanStatus { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public int? CreditScore { get; set; }
        public bool? LoanDocumentsVerified { get; set; }

        public virtual Customer? Customer { get; set; }
    }
}
