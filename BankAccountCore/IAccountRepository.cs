namespace BankAccountCore
{
    public interface IAccountRepository
    {
        void Save(List<BankAccount> accounts);
        List<BankAccount> Load();
    }
}
