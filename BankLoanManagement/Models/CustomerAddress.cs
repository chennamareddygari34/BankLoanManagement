using System;
using System.Collections.Generic;

namespace BankLoanManagement.Models
{
    public partial class CustomerAddress
    {
        public CustomerAddress()
        {
            Customers = new HashSet<Customer>();
        }

        public int AddressId { get; set; }
        public string? HouseNo { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? State { get; set; }
        public string? Landmark { get; set; }
        public int? Pincode { get; set; }
        public string? Country { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
