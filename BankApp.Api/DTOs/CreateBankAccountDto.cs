using System.ComponentModel.DataAnnotations;

namespace BankApp.Api.DTOs
{
    public class CreateBankAccountDto
    {
        [Required(ErrorMessage = "Owner name is required.")]
        [StringLength(100, MinimumLength = 2)]
        public string OwnerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(100, MinimumLength = 2)]
        public string UserName {  get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;
    }
}
