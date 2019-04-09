using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Models.Interfaces
{
    public interface IAccountRepository
    {   //Load an account by account number
        Account LoadAccount(string AccountNumber);

        //Be able to save an account
        //pass account details
        void SaveAccount(Account account);
    }
}
