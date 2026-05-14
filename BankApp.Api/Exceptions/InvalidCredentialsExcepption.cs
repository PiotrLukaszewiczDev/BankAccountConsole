namespace BankApp.Api.Exceptions
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException() : base("Incorrect username or password.") { }
    }
}
