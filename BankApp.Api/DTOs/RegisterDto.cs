namespace BankApp.Api.DTOs
{
    public class RegisterDto
    {
        public string OwnerName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
