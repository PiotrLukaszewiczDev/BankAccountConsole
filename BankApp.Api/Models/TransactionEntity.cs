using BankAccountCore; 

namespace BankApp.Api.Models
{
    public class TransactionEntity
    {
        public int Id { get; set; }
        public int BankAccountId { get; set; }
        public decimal Amount { get; set; }
        public decimal BalanceAfter { get; set; }
        public DateTime Date { get; set;  }
        public TransactionType Type { get; set; }
        public BankAccountEntity BankAccount { get; set; } = null!;
    }
}
