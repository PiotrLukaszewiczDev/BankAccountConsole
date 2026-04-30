using BankAccountCore;
using System.Windows.Input;

namespace WpfBankAccount.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private string _ownerName;
        private string _username;
        private string _password;
        private string _confirmPassword;
        private string _errorMessage;
        private readonly IAuthService _authService;

        public string OwnerName
        {
            get => _ownerName;
            set
            {
                _ownerName = value;
                OnPropertyChanged();
                CommandManager.InvalidateRequerySuggested();
            }
        }
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
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
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
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
        public ICommand RegisterCommand { get; }

        public RegisterViewModel(INavigationService navigationService, IAuthService authService)
            : base(navigationService)
        {
            _authService = authService;
            RegisterCommand = new RelayCommand(Register, CanRegister);
        }
        private void Register(object parameter)
        {
            try
            {
                string password = parameter as string ?? Password;
                var account = _authService.Register(OwnerName, Username, password);
                _navigationService.NavigateTo(Navigation.ViewType.Login, null);
            }
            catch (UserAlreadyExistsException ex)
            {
                ErrorMessage = ex.Message;
            }
        }
        private bool CanRegister(object parameter)
        {
            return !string.IsNullOrWhiteSpace(OwnerName) &&
                    !string.IsNullOrWhiteSpace(Username) &&
                    !string.IsNullOrWhiteSpace(Password) &&
                    Password == ConfirmPassword;

        }
        protected override void Back(object parameter)
        {
            _navigationService.NavigateTo(Navigation.ViewType.Login, null);
        }
    }
}
