namespace BankLoanManagement.Utilities
{
    public class ListNotFoundException:Exception
    {
        string message = "";
        public ListNotFoundException()
        {
            message = "no data or list found as of now please add";
        }
        public override string Message => message;
    }
}
