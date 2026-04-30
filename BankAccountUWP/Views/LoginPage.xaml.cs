using BankAccountLibrary.Services;
using BankAccountUWP.ViewModels;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace BankAccountUWP.Views
{
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
            var auth = ((App)Application.Current).AuthService;
            var vm = new LoginPageViewModel(auth);
            
            this.DataContext = vm;
        }
      
        private LoginPageViewModel ViewModel => (LoginPageViewModel)DataContext;

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (ViewModel == null) return;
            ViewModel.Password = ((PasswordBox)sender).Password;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
            else
            {
                Frame.Navigate(typeof(MainMenuPage));
            }
        }
    }
}