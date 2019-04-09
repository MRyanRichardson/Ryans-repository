﻿using SGBank.Models;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Data
{
    public class BasicAccountTestRepository : IAccountRepository
    {
        private static Account _basicAccount = new Account
        {
            Name = "Basic Account",
            Balance = 100.00M,
            AccountNumber = "33333",
            Type = AccountType.Basic
        };

        public Account LoadAccount(string BasicAccountNumber)
        {
            if (BasicAccountNumber == _basicAccount.AccountNumber)
            {
                return _basicAccount;
            }
            else
            {
                return null;
            }
        }

        public void SaveAccount(Account basicAccount)
        {
            _basicAccount = basicAccount;
        }
    }
}