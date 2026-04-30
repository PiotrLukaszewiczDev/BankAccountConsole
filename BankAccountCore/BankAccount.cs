using System.Text.Json.Serialization;

namespace BankAccountCore
{
    public class BankAccount
    {
        public BankAccount(string accountNumber, string ownerName, string username, string password)
            : this(accountNumber, ownerName, username, password, 0)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be empty.");
            if (string.IsNullOrWhiteSpace(ownerName))
                throw new ArgumentException("Name and surname cannot be empty.");
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be empty.");
        }
        
        [JsonConstructor]
        public BankAccount(string accountNumber, string ownerName, string username, string password, decimal balance)
        {
            AccountNumber = accountNumber;
            OwnerName = ownerName;
            Username = username;
            _password = password;
            Balance = balance;
        }
        private string _password;
        [JsonInclude]
        public string AccountNumber { get; private set; }
        public string OwnerName { get; private set; }
        public string Username { get; private set; }
        public decimal Balance { get; set; }
        public string Password => _password;
        public List<Transaction> Transactions
        {
            get { return _transactions; }
            set
            {
                if (value != null)
                {
                    _transactions = value;
                }
                else
                {
                    _transactions = new List<Transaction>();
                }
            }

        }

        private List<Transaction> _transactions = new List<Transaction>();

        public void AddTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
        }
        public bool Authenticate(string password)
        {
            return _password == password;
        }
        public IEnumerable<Transaction> GetTransactionHistory()
        {
            List<Transaction> sortedTransacions = new List<Transaction>(_transactions);
            sortedTransacions.Sort((a, b) => b.Date.CompareTo(a.Date));
            return sortedTransacions;
        }
        public override string ToString()
        {
            return $"{Username} ({OwnerName})";
        }

    }
}
