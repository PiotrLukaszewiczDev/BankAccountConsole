using AutoMapper;
using BankAccountCore;
using BankApp.Api.DTOs;
using BankApp.Api.Interfaces;
using BankApp.Api.Models;
using Microsoft.AspNetCore.Http.Connections;

namespace BankApp.Api.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IBankAccountRepository _bankRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionService(IBankAccountRepository bankRepository, ITransactionRepository transactionRepository, IMapper mapper)
        {
            _bankRepository = bankRepository;
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }
        public async Task<TransactionDto> DepositAsync(decimal amount, int bankAccountId)
        {
            var account = await _bankRepository.GetByIdAsync(bankAccountId);
            if (account == null)
            {
                throw new ArgumentException($"Account with Id {bankAccountId} don't exists");
            }
            
            account.Balance += amount;
            await _bankRepository.UpdateAsync(account);

            var transactionEntity = new TransactionEntity
            {
                BankAccountId = bankAccountId,
                Amount = amount,
                BalanceAfter = account.Balance,
                Date = DateTime.UtcNow,
                Type = TransactionType.Deposit
            };

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
            
            if(account.Balance < amount)
            {
                throw new InsufficientFundsException();
            }
            account.Balance -= amount;
            await _bankRepository.UpdateAsync(account);

            var transactionEntity = new TransactionEntity
            {
                BankAccountId = bankAccountId,
                Amount = amount,
                BalanceAfter = account.Balance,
                Date = DateTime.UtcNow,
                Type = TransactionType.Withdrawal
            };

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
