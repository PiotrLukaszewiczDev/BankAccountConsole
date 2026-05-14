using BankApp.Api.Data;
using BankApp.Api.Exceptions;
using BankApp.Api.Interfaces;
using BankApp.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Api.Repositories
{

    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly BankAppDbContext _context;

        public BankAccountRepository(BankAppDbContext context)
        {
            _context = context;
        }

        public async Task<BankAccountEntity> CreateAsync(BankAccountEntity bankAccountEntity)
        {
            _context.AccountEntities.Add(bankAccountEntity);
            await _context.SaveChangesAsync();
            return (bankAccountEntity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.AccountEntities.FindAsync(id);

            if (existing == null)
            {
                return false;
            }
            _context.AccountEntities.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.AccountEntities.AnyAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<BankAccountEntity>> GetAllAsync()
        {
            return await _context.AccountEntities.ToListAsync();
        }

        public async Task<BankAccountEntity?> GetByIdAsync(int id)
        {
            return await _context.AccountEntities.FindAsync(id);
        }

        public async Task<BankAccountEntity?> GetByUsernameAsync(string username)
        {
            return await _context.AccountEntities.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<BankAccountEntity> UpdateAsync(BankAccountEntity bankAccountEntity)
        {
            var existing = await _context.AccountEntities.FindAsync(bankAccountEntity.Id);

            if (existing == null)
            {
                throw new AccountNotFoundException();
            }

            existing.OwnerName = bankAccountEntity.OwnerName;
            existing.UserName = bankAccountEntity.UserName;
            existing.Balance = bankAccountEntity.Balance;
            existing.Password = bankAccountEntity.Password;

            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
