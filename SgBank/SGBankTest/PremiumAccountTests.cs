using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.BLL.DepositRules;
using SGBank.Models.Responses;
using SGBank.BLL.WithdrawRules;

namespace SGBankTest
{
    [TestFixture]
    public class PremiumAccountTests
    {
        [Test]
        [TestCase("54321", "Premium Account", 100, AccountType.Free, 250, false)]
        [TestCase("54321", "Premium Account", 100, AccountType.Premium, -100, false)]
        [TestCase("54321", "Premium Account", 100, AccountType.Premium, 250, true)]

        public void PremiumAccountDepositRuleTests(string accountNumber, string name, decimal balance,
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
        
            [TestCase("54321", "Premium Account", 100, AccountType.Free, -100, 100, false)]
            [TestCase("54321", "Premium Account", 100, AccountType.Premium, 100, 100, false)]
            [TestCase("54321", "Premium Account", 100, AccountType.Premium, -650, -560, true)]

        public void PremiumAccountWithdrawRuleTests(string accountNumber, string name, decimal balance,
            AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {
            IWithDraw bWithdraw = new PremiumAccountWithdrawRules();
            Account pAcct = new Account();

            pAcct.AccountNumber = accountNumber;
            pAcct.Name = name;
            pAcct.Balance = balance;
            pAcct.Type = accountType;


            AccountWithDrawResponse aResponse = bWithdraw.Withdraw(pAcct, amount);

            Assert.AreEqual(expectedResult, aResponse.Success);

            if (aResponse.Success == true)
            {
                Assert.AreEqual(newBalance, aResponse.Balance);

            }
        }
    }
}
