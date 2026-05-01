using BankAccountCore;
using System.ComponentModel.DataAnnotations;
namespace BankApp.Api.DTOs
{
    public class CreateTransactionDto
    {
        [Range(0.01, double.MaxValue, ErrorMessage ="Amount must be greater than 0.")]
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }    
    }
}
