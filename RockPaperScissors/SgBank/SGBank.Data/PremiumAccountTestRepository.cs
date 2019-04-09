using SGBank.Models;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Data
{
    public class PremiumAccountTestRepository : IAccountRepository
    {
        private static Account _premiumAccount = new Account
        {
            Name = "Premium Account",
            Balance = 100.00M,
            AccountNumber = "54321",
            Type = AccountType.Premium
        };

        public Account LoadAccount(string PremiumAccountNumber)
        {
            if (PremiumAccountNumber == _premiumAccount.AccountNumber)
            {
                return _premiumAccount;
            }

            else
            {
                return null;
            }
        }

        public void SaveAccount(Account premiumAccount)
        {
            _premiumAccount = premiumAccount;
        }
    }
}
