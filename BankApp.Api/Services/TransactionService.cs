using AutoMapper;
using BankAccountCore;
using BankApp.Api.DTOs;
using BankApp.Api.Interfaces;
using BankApp.Api.Models;

namespace BankApp.Api.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IBankAccountRepository _bankRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly BankAccountCore.TransactionService _accountCore;
        private readonly IMapper _mapper;

        public TransactionService(IBankAccountRepository bankRepository, ITransactionRepository transactionRepository,
            BankAccountCore.TransactionService accountCore, IMapper mapper)
        {
            _bankRepository = bankRepository;
            _transactionRepository = transactionRepository;
            _accountCore = accountCore;
            _mapper = mapper;
        }
        public async Task<TransactionDto> DepositAsync(decimal amount, int bankAccountId)
        {
            var account = await _bankRepository.GetByIdAsync(bankAccountId);
            if (account == null)
            {
                throw new ArgumentException($"Account with Id {bankAccountId} don't exists");
            }
            
            var domainAccount = _mapper.Map<BankAccount>(account);
            _accountCore.Deposit(domainAccount, amount);

            account.Balance = domainAccount.Balance;
            await _bankRepository.UpdateAsync(account);

            var lastTransaction = domainAccount.Transactions.Last();
            var transactionEntity = _mapper.Map<TransactionEntity>(lastTransaction);
            transactionEntity.BankAccountId = bankAccountId;
            await _transactionRepository.CreateAsync(transactionEntity);

            return _mapper.Map<TransactionDto>(transactionEntity);
        }

        public async Task<TransactionDto> WithdrawalAsync(decimal amount, int bankAccountId)
        {
            var account = await _bankRepository.GetByIdAsync(bankAccountId);
            if (account == null)
            {
                throw new ArgumentException($"Account with Id {bankAccountId} don't exists"); 
            }
            var domainAccount = _mapper.Map<BankAccount>(account);
            _accountCore.Withdrawal(domainAccount, amount);

            account.Balance = domainAccount.Balance;
            await _bankRepository.UpdateAsync(account);

            var lastTransaction = domainAccount.Transactions.Last();
            var transactionEntity = _mapper.Map<TransactionEntity>(lastTransaction);
            transactionEntity.BankAccountId = bankAccountId;
            await _transactionRepository.CreateAsync(transactionEntity);

            return _mapper.Map<TransactionDto>(transactionEntity);
        }
        
        public async Task<IEnumerable<TransactionDto>> GetAllByAccountIdAsync(int accountId)
        {
            var transaction = await _transactionRepository.GetAllByAccountIdAsync(accountId);
            var getAll = _mapper.Map<IEnumerable<TransactionDto>>(transaction);

            return getAll;
        }
    }
}
