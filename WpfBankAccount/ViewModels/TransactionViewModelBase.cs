using BankAccountCore;

namespace WpfBankAccount.ViewModels
{
    public abstract class TransactionViewModelBase : ViewModelBase
    {
        private decimal _amount;
        private string _errorMessage;
        protected BankAccount Account => _account;

        public string OwnerName => _account.OwnerName;
        public string AccountNumber => _account.AccountNumber;
        public decimal Balance => _account.Balance;
        public decimal Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                OnPropertyChanged();
                ErrorMessage = string.Empty;
            }
        }
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HasError));
            }
        }
        protected TransactionViewModelBase(BankAccount account, INavigationService navigationService)
            :base(navigationService, account)
        {
        }
        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);
    }
}
