using Microsoft.EntityFrameworkCore;
using BankApp.Api.Models;
using System.Reflection;

namespace BankApp.Api.Data
{
    public class BankAppDbContext : DbContext
    {
        public BankAppDbContext(DbContextOptions<BankAppDbContext> options) : base(options)
        {
        }

        public DbSet<BankAccountEntity> AccountEntities { get; set; }
        public DbSet<TransactionEntity> TransactionEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
