using System;
using System.Collections.Generic;

namespace BankAccountCore
{
    public class AuthService : IAuthService
    {
        private List<BankAccount> _registeredAccounts;
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountNumberGenerator _accountNumberGenerator;

        public AuthService(IAccountRepository accountRepository, IAccountNumberGenerator accountNumberGenerator)
        {
            _accountRepository = accountRepository;
            _accountNumberGenerator = accountNumberGenerator;
            _registeredAccounts = _accountRepository.Load();
        }
        public IEnumerable<BankAccount> GetAllAccounts()
        {
            return _registeredAccounts;
        }
        public void SaveCurrentState()
        {
            _accountRepository.Save(_registeredAccounts);
        }
       
        public BankAccount Register(string ownerName, string username, string password)
        {
            foreach (var account in _registeredAccounts)
            {
                if (account.Username == username)
                {
                    throw new UserAlreadyExistsException();
                }
            }
            string accountNumber = _accountNumberGenerator.Generate();
            var newAccount = new BankAccount(accountNumber, ownerName, username, password);
            _registeredAccounts.Add(newAccount);
            _accountRepository.Save(_registeredAccounts);
            return newAccount;
        }
        public BankAccount Login(string username, string password)
        {
            BankAccount foundAccount = null;

            foreach (var account in _registeredAccounts)
            {
                if (account.Username == username)
                {
                    foundAccount = account;
                }
            }
            if (foundAccount == null || !foundAccount.Authenticate(password))
            {
                throw new InvalidCredentialsException();
            }
            return foundAccount;
        }
    }
}
