using NUnit.Framework;
using SGBank.BLL;
using SGBank.Models.Responses;
using SGBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models.Interfaces;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;

namespace SGBankTest
{
    [TestFixture]
    public class FreeAccountTests
    {

        [Test]
        [TestCase("12345", "Free Account", 100, AccountType.Free, 250, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, -100, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Basic, 50, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, 50, true)]

        public void FreeAccountDepositRuleTest(string accountNumber,
        string name,
        decimal balance,
        AccountType accountType,
        decimal amount,
        bool expectedResult)
        {
            IDeposit iDep = new FreeAccountDepositRule();
            Account acct = new Account();

            acct.AccountNumber = accountNumber;
            acct.Name = name;
            acct.Balance = balance;
            acct.Type = accountType;

            AccountDepositResponse adr = iDep.Deposit(acct, amount);

            Assert.AreEqual(expectedResult , adr.Success);
        }

        [Test]
        [TestCase("12345", "Free Account", 100, AccountType.Free, 50, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, -150, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Basic, -50, false)]
        [TestCase("12345", "Free Account", 50, AccountType.Free, -75, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, -50, true)]

        public void FreeAccountWithDrawRuleTest(string accountNumber,
        string name,
        decimal balance,
        AccountType accountType,
        decimal amount,
        bool expectedResult)
        {
            IWithDraw iWd = new FreeAccountWithdrawRule();
            Account acct = new Account();

            acct.AccountNumber = accountNumber;
            acct.Name = name;
            acct.Balance = balance;
            acct.Type = accountType;

            AccountWithDrawResponse awr = iWd.Withdraw(acct, amount);

            Assert.AreEqual(expectedResult, awr.Success); 
        }
    }
}
