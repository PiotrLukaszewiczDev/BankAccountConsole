using BankAccountCore;
using System.Windows.Input;
using WpfBankAccount.Navigation;

namespace WpfBankAccount.ViewModels
{
    public class CheckBalanceViewModel 
    {
        private readonly INavigationService _navigationService;
        private readonly BankAccount _account;

        public string OwnerName => _account.OwnerName;
        public string AccountNumber => _account.AccountNumber;
        public decimal Balance => _account.Balance;
        public ICommand BackCommand { get; }
                            
        public CheckBalanceViewModel(INavigationService navigationService, BankAccount account)
        {
            _navigationService = navigationService;
            _account = account;

            BackCommand = new RelayCommand(Back, CanBack);
        }
        private void Back(object parameter)
        {
            _navigationService.NavigateTo(ViewType.Menu, _account);
        }
        private bool CanBack(object parameter)
        {
            return true;
        }
    }
}
