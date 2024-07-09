using System;
using System.Collections.Generic;

namespace BankLoanManagement.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public byte[] Password { get; set; } = null!;
        public byte[] Key { get; set; } = null!;
    }
}
