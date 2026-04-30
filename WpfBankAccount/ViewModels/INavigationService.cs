using WpfBankAccount.Navigation;
namespace WpfBankAccount.ViewModels
{
    public interface INavigationService 
    {
        void NavigateTo(ViewType viewType, object parameter = null);
        event EventHandler<NewViewModelEventArgs> CurrentViewModelChanged; 
    }
}

