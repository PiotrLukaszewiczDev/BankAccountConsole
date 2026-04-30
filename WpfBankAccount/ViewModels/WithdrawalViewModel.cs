using BankAccountCore;
using System.Windows.Input;

namespace WpfBankAccount.ViewModels
{
    public class WithdrawalViewModel : TransactionViewModelBase
    {
        private readonly IAuthService _authService;
        private readonly TransactionService _transactionService;
        public ICommand WithdrawalCommand { get; }
        public WithdrawalViewModel(INavigationService navigationService, IAuthService authService, BankAccount account, TransactionService transactionService)
            : base(account, navigationService)
        {
            _authService = authService;
            _transactionService = transactionService;

            WithdrawalCommand = new RelayCommand(ExecuteWithdrawal, CanExecuteWithdrawal);
        }
        private void ExecuteWithdrawal(object parameter)
        {
            try
            {
                _transactionService.Withdrawal(Account, Amount);
                _authService.SaveCurrentState();
                OnPropertyChanged(nameof(Balance));
                ErrorMessage = string.Empty;
                Amount = 0;
            }
            catch(ArgumentException ex)
            {
                ErrorMessage = ex.Message;
            }
            catch(InsufficientFundsException ex)
            {
                ErrorMessage = ex.Message;
            }
        }
        private bool CanExecuteWithdrawal(object parameter)
        {
            return Amount > 0;
        }
    }
}
