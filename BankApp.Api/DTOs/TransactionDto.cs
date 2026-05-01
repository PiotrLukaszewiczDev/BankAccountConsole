using BankAccountCore;

namespace BankApp.Api.DTOs
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; } 
        public DateTime Date { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal BalanceAfter { get; set; }
    }
}
