﻿using System;
using System.Collections.Generic;

namespace BankLoanManagement.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Loans = new HashSet<Loan>();
        }

        public int CustomerId { get; set; }
        public long? AccountNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public long? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? MaritalStatus { get; set; }
        public string? OccupationType { get; set; }
        public int? AddressId { get; set; }

        public virtual CustomerAddress? Address { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
