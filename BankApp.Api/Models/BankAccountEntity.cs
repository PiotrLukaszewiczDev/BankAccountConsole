namespace BankApp.Api.Models
{
    public class BankAccountEntity
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public string OwnerName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public string Password { get; set; } = string.Empty;
        public List<TransactionEntity> Transactions { get; set; } = new List<TransactionEntity>();
    }
}
