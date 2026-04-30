using BankAccountCore;
using System.Windows.Input;

namespace WpfBankAccount.ViewModels
{
    public class DepositViewModel : TransactionViewModelBase
    {
        private readonly IAuthService _authService;
        private readonly TransactionService _transactionService;
        public ICommand DepositCommand { get; }
        public DepositViewModel(INavigationService navigationService, IAuthService authService, BankAccount account, TransactionService transactionService)
            : base(account, navigationService)
        {
            _transactionService = transactionService;
            _authService = authService;

            DepositCommand = new RelayCommand(ExecuteDeposit, CanExecuteDeposit);
        }
        private void ExecuteDeposit(object parameter)
        {
            try
            {
                _transactionService.Deposit(Account, Amount);
                _authService.SaveCurrentState();
                OnPropertyChanged(nameof(Balance));
                ErrorMessage = string.Empty;
                Amount = 0;
            }
            catch (ArgumentException ex)
            {
                ErrorMessage = ex.Message; //Napisać swój wyjątek.
            }
        }
        private bool CanExecuteDeposit(object parameter)
        {
            return Amount > 0;
        }
    }
}
