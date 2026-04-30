using System;

namespace BankAccountCore
{
    public enum TransactionType
    {
        Deposit,
        Withdrawal
    }
    public class Transaction
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public TransactionType Type { get; set; }
        public decimal BalanceAfter { get; set; }
    }
}
