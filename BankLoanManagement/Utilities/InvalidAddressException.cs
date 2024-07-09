namespace BankLoanManagement.Utilities
{
    public class InvalidAddressException : Exception
    {
        string message = "";
        public InvalidAddressException() 
        {
            message = "There is incorrect data . Can you please add the correct Data";
        }
    }
}
