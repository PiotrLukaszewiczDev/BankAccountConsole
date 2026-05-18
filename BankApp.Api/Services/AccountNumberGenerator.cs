namespace BankApp.Api.Services
{
    public class AccountNumberGenerator : BankAccountCore.IAccountNumberGenerator
    {
        public string Generate()
        {
            return "DE" + Random.Shared.Next(10000000, 99999999).ToString();
        }
    }
}
