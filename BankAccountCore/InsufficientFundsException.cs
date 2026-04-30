namespace BankAccountCore
{
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException() : base("Insufficient funds") { }
    }
}
