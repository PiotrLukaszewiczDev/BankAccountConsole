using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfBankAccount.Navigation;

namespace WpfBankAccount.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly INavigationService _navigationService;
        private object _currentView;

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _navigationService.CurrentViewModelChanged += NavigationService_CurrentViewModelChanged;
            _navigationService.NavigateTo(ViewType.Login);
        }

        private void NavigationService_CurrentViewModelChanged(object? sender, NewViewModelEventArgs e)
        {
            CurrentView = e.NewViewModel;
        }

        public object CurrentView
        {
            get => _currentView;
            set 
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
