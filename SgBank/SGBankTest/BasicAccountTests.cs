using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;

namespace SGBankTest
{   [TestFixture]
    public class BasicAccountTests
    {
        [Test]
        [TestCase("33333", "Basic Account", 100, AccountType.Free, 250, false)]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, -100, false)]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, 250, true)]

        public void BasicAccountDepositRuleTests(string accountNumber, string name, decimal balance,
            AccountType accountType, decimal amount, bool expectedResult)           
        {
            IDeposit bDep = new NoLimitDepositRule();
            Account bAcct = new Account();

            bAcct.AccountNumber = accountNumber;
            bAcct.Name = name;
            bAcct.Balance = balance;
            bAcct.Type = accountType;

            AccountDepositResponse aResponse = bDep.Deposit(bAcct, amount);

            Assert.AreEqual(expectedResult, aResponse.Success);
        }

        [Test]
        [TestCase("33333", "Basic Account", 1500, AccountType.Basic, -1000, 1500,  false)]
        [TestCase("33333", "Basic Account", 100, AccountType.Free, -100, 100, false)]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, 100, 100, false)]
        [TestCase("33333", "Basic Account", 150, AccountType.Basic, -50, 100, true)]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, -150, -60, true)]

        public void BasicAccountWithdrawRuleTests(string accountNumber, string name, decimal balance,
            AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {
            IWithDraw bWithdraw = new BasicAccountWithdrawRule();
            Account bAcct = new Account();

            bAcct.AccountNumber = accountNumber;
            bAcct.Name = name;
            bAcct.Balance = balance;
            bAcct.Type = accountType;
            
                     
            AccountWithDrawResponse aResponse = bWithdraw.Withdraw(bAcct, amount);
            
            Assert.AreEqual(expectedResult, aResponse.Success);

            if (aResponse.Success == true)
            {
                Assert.AreEqual(newBalance, aResponse.Balance);

            }

        }
    }
}
