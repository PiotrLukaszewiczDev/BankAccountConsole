using BankAccountCore;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WpfBankAccount.Navigation;

namespace WpfBankAccount.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        protected readonly BankAccount _account;
        protected readonly INavigationService _navigationService;
        public ICommand BackCommand { get; }
        protected ViewModelBase(INavigationService navigationService, BankAccount? account = null)
        {
            _navigationService = navigationService;
            _account = account;
            BackCommand = new RelayCommand(Back, CanBack);
        }
        protected virtual void Back(object parameter)
        {
            _navigationService.NavigateTo(ViewType.Menu, _account);
        }
        protected virtual bool CanBack(object parameter)
        {
            return true;
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
