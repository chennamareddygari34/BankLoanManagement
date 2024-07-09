using System;
using System.Collections.Generic;

namespace BankLoanManagement.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
        public string Nationality { get; set; } = null!;
        public string MaritalStatus { get; set; } = null!;
        public string OccupationType { get; set; } = null!;
        public string HouseNo { get; set; } = null!;
        public string City { get; set; } = null!;
        public string District { get; set; } = null!;
        public string State { get; set; } = null!;
        public string? Landmark { get; set; }
        public int Pincode { get; set; }
    }
}
