namespace BankLoanManagement.Models.DTOs
{
  public class CustomerDTO
  {
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

        public  CustomerAddress? Address { get; set; }
    }
}
