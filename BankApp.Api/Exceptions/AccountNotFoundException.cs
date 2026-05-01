namespace BankApp.Api.Exceptions
{
    public class AccountNotFoundException : Exception
    {
        public AccountNotFoundException() :  base("User with this Id not exists.") { }
    }
}
