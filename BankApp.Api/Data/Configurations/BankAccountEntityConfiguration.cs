using BankApp.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BankApp.Api.Data.Configurations
{
    public class BankAccountEntityConfiguration : IEntityTypeConfiguration<BankAccountEntity>
    {
        public void Configure(EntityTypeBuilder<BankAccountEntity> builder) 
        {
            builder.Property(b => b.Balance).HasColumnType("decimal(18,2)");
        }
    }
}
