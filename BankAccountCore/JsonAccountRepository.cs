using System.Text.Json;

namespace BankAccountCore
{
    public class JsonAccountRepository : IAccountRepository
    {
        private static readonly string _filePath = "account.json";

        public void Save(List<BankAccount> accounts)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = null
            };
            string json = JsonSerializer.Serialize(accounts, options);
            File.WriteAllText(_filePath, json);
        }
        public List<BankAccount> Load()
        {
            if (!File.Exists(_filePath))
            {
                return  new List<BankAccount>();
            }
            string json = File.ReadAllText(_filePath);
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = null
            };
            try
            {
                List<BankAccount> accounts = JsonSerializer.Deserialize<List<BankAccount>>(json, options);
                if (accounts == null)
                {
                    return new List<BankAccount>();
                }
                return accounts;
            }
            catch (JsonException)
            {
                return new List<BankAccount>();
            }
        }
    }
}
