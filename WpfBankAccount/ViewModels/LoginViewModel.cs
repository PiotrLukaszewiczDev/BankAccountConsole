using BankAccountCore;
using System.Windows.Input;
using WpfBankAccount.Navigation;

namespace WpfBankAccount.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _userName;
        private string _password;
        private string _errorMessage;
        private readonly IAuthService _authService;

        public string Username
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
                CommandManager.InvalidateRequerySuggested();
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
                CommandManager.InvalidateRequerySuggested();
            }
        }
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }
        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public LoginViewModel(INavigationService navigationService, IAuthService authService)
            : base(navigationService, null)
        {
            _authService = authService;

            LoginCommand = new RelayCommand(Login, CanLogin);
            RegisterCommand = new RelayCommand(Register, CanRegister);
        }
        private void Login(object parameter)
        {
            try
            {
                string password = parameter as string ?? Password;
                var account = _authService.Login(Username, password);
                _navigationService.NavigateTo(ViewType.Menu, account);
            }
            catch (InvalidCredentialsException ex)
            {
                ErrorMessage = ex.Message;
            }
        }
        private void Register(object parameter)
        {
            _navigationService.NavigateTo(ViewType.Register, null);
        }
        private bool CanLogin(object parameter)
        {
            string password = parameter as string ?? Password;
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(password);
        }
        private bool CanRegister(object parameter)
        {
            return true;
        }
    }
}
