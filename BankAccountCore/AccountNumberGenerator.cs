namespace BankAccountCore
{
    public class AccountNumberGenerator : IAccountNumberGenerator
    {
        private readonly AccountDataService _accountDataService;
        public AccountNumberGenerator(AccountDataService accountDataService)
        {
            _accountDataService = accountDataService;
        }
        public string Generate()
        {
            int seed = _accountDataService.LoadAccountNumberSeed();
            string accountNumber = "PL" + seed.ToString();
            _accountDataService.SaveAccountNumberSeed(seed + 1);
            return accountNumber;
        }
    }
}

