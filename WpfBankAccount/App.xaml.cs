using BankAccountCore;
using System.Windows;
using WpfBankAccount.ViewModels;
using WpfBankAccount.Views;

namespace WpfBankAccount
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            AccountDataService accountDataService = new AccountDataService();
            IAccountRepository accountRepository = new JsonAccountRepository();
            IAccountNumberGenerator accountNumberGenerator = new AccountNumberGenerator(accountDataService);
            IAuthService authService = new AuthService(accountRepository, accountNumberGenerator);
            IViewModelFactory viewModelFactory = new ViewModelFactory(authService);
            INavigationService navigationService = new NavigationService(viewModelFactory);

            var mainViewModel = new MainViewModel(navigationService);
            var mainWindow = new MainWindow
            {
                DataContext = mainViewModel
            };

            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
