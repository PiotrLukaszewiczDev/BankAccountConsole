using WpfBankAccount.Navigation;

namespace WpfBankAccount.ViewModels
{
    public class NavigationService : INavigationService
    {
        private readonly IViewModelFactory _factory;

        public event EventHandler<NewViewModelEventArgs> CurrentViewModelChanged;

        public NavigationService(IViewModelFactory factory) 
        {
            _factory = factory;
        }

        public void NavigateTo(ViewType viewType, object parameter)
        {
            object vm = _factory.Create(this, viewType, parameter);
            CurrentViewModelChanged?.Invoke(this, new NewViewModelEventArgs(vm));
        }
    }
}