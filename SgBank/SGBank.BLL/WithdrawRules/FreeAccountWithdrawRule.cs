using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;

namespace SGBank.BLL.WithdrawRules
{
    public class FreeAccountWithdrawRule : IWithDraw
    {
        public AccountWithDrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithDrawResponse awr = new AccountWithDrawResponse();

            if (account.Type != AccountType.Free)
            {
                awr.Success = false;
                awr.Message = "Error: A non free account hit the Free Withdraw Rule. Contact IT";
                return awr;
            }

            if (amount >= 0)
            {
                awr.Success = false;
                awr.Message = "Withdrawal amounts must be negative!";
                return awr;
            }
            if (amount < -100)
            {
                awr.Success = false;
                awr.Message = "Free accounts cannot withdraw more than $100";
                return awr;
            }
            if (account.Balance + amount < 0)
            {
                awr.Success = false;
                awr.Message = "Free accounts cannot overdraft!";
                return awr;
            }

            awr.Success = true;
            awr.Amount = amount;
            awr.OldBalance = account.Balance;
            account.Balance += amount;
            awr.Account = account;
            
            

            return awr;
        }
    }
}
