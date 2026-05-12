using BankApp.Api.Data;
using BankApp.Api.Interfaces;
using BankApp.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Api.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly BankAppDbContext _context;

        public TransactionRepository(BankAppDbContext context)
        {
            _context = context;
        }
        public async Task<TransactionEntity> CreateAsync(TransactionEntity transactionEntity)
        {
            _context.TransactionEntities.Add(transactionEntity);
            await _context.SaveChangesAsync();
            return(transactionEntity);
        }

        public async Task<IEnumerable<TransactionEntity>> GetAllByAccountIdAsync(int bankAccountId)
        {
            return await _context.TransactionEntities
                .Where(t => t.BankAccountId == bankAccountId)
                .ToListAsync();
        }
    }
}
