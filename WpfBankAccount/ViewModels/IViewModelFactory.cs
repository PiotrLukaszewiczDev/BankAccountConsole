using WpfBankAccount.Navigation;

namespace WpfBankAccount.ViewModels
{
    public interface IViewModelFactory
    {
        object Create(INavigationService navigationService, ViewType viewType, object parameter = null);
    }
}
