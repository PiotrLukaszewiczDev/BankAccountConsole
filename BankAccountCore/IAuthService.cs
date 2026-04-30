namespace BankAccountCore
{
    public interface IAuthService
    {
        BankAccount Login(string username, string password);
        BankAccount Register(string ownerName, string username, string password);
        void SaveCurrentState();
    }
}
