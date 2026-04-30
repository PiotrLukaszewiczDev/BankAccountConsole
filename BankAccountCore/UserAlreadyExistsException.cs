namespace BankAccountCore
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException() : base("This user already exists") { }
    }
}
