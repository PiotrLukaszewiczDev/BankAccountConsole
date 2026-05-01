namespace BankApp.Api.DTOs
{
    public class BankAccountDto
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public string OwnerName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public decimal Balance { get; set; }
    }
}
