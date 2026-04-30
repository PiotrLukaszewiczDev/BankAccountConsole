using BankAccountLibrary.Services;
using BankAccountUWP.Helpers;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace BankAccountUWP.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        private readonly AuthService authService;
        //private string _username;
        //private string _password;
        private string _errorMessage;

        public event Action RegisterRequested;
        public event Action LoginSucceeded;

        //public string Username
        //{
        //    get => _username;
        //    set
        //    {
        //        if (_username == value) return;
        //        _username = value;
        //        this.OnPropertyChanged(nameof(Username));
        //        CommandManagerHepler.RaiseCanExecuteChanged();
        //    }
        //}

        //public string Password
        //{
        //    get => _password;
        //    set
        //    {
        //        if (_password == value) return;
        //        _password = value;
        //        this.OnPropertyChanged(nameof(Password));
        //        CommandManagerHepler.RaiseCanExecuteChanged();
        //    }
        //}

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                if (_errorMessage == value) return;
                _errorMessage = value;
                this.OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public ICommand LoginClicked { get; }
        public ICommand RegisterClicked { get; }

        public LoginPageViewModel(AuthService authService) // Poszukać przyczyny tutaj
        {
           // this.authService = authService ?? throw new ArgumentNullException(nameof(authService));
           // LoginClicked = new RelayCommand(OnLoginClicked, _ => !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password));
           // RegisterClicked = new RelayCommand(OnRegisterClicked);

        }


        private void OnLoginClicked(object obj)
        {
            try
            {
                var account = authService.Login(Username, Password);
                ErrorMessage = string.Empty;
                LoginSucceeded?.Invoke();
            }
            catch (UnauthorizedAccessException uaEx)
            {
                ErrorMessage = uaEx.Message;
            }
            catch (Exception ex)
            {
                ErrorMessage = "Wystąpił błąd: " + ex.Message;
            }
        }


        private void OnRegisterClicked(object obj)
        {
            RegisterRequested?.Invoke();
        }

        public event PropertyChangedEventHandler PropertyChanged; // Sprawdzić to
        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}