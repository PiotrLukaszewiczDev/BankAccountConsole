namespace WpfBankAccount.Navigation
{
    public class NewViewModelEventArgs : EventArgs
    {
        public object NewViewModel { get; }

        public NewViewModelEventArgs(object newViewModel)
        {
            NewViewModel = newViewModel;
        }

    }
}
