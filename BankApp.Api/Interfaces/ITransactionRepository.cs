using BankApp.Api.Models;

namespace BankApp.Api.Interfaces
{
    public interface ITransactionRepository
    {
        Task<TransactionEntity> CreateAsync(TransactionEntity transactionEntity);
        Task<IEnumerable<TransactionEntity>> GetAllByAccountIdAsync(int bankAccountId);
    }
}
