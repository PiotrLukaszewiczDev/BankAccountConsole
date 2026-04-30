using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountCore
{
    public interface IAccountRepository
    {
        void Save(List<BankAccount> accounts);
        List<BankAccount> Load();
    }
}
