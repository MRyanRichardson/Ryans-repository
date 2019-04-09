using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL.WithdrawRules
{
    public class BasicAccountWithdrawRule : IWithDraw
    {
        public AccountWithDrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithDrawResponse basicResponse = new AccountWithDrawResponse();
            //basicResponse.Success = false;
            //basicResponse.Amount = amount;
            //basicResponse.OldBalance = account.Balance;

            if (account.Type != AccountType.Basic)
            {
                basicResponse.Success = false;
                basicResponse.Message = "Error: A non-basic account hit the Basic Withdraw Rule. Contact IT";
                return basicResponse;
            }

            if (amount >= 0)
            {
                basicResponse.Success = false;
                basicResponse.Message = "Withdrawal amounts must be negative!";
                return basicResponse;
            }
            if (amount < -500)
            {
                basicResponse.Success = false;
                basicResponse.Message = "Basic accounts cannot withdraw more than $500";
                return basicResponse;
            }
            if (account.Balance + amount < -100)
            {
                basicResponse.Success = false;
                basicResponse.Message = "This amount will overdraft more than your $100 limit!";
                return basicResponse;
            }

            
            basicResponse.Amount = amount;// can comment out
            basicResponse.OldBalance = account.Balance;//can comment out
            account.Balance += amount;
            

            if(account.Balance < 0)
            {
                basicResponse.Success = true;
                account.Balance -=  10;

                //sets balance to new balance(returning new balance)
                basicResponse.Balance = account.Balance;
                basicResponse.Account = account;
                return basicResponse;
            };

            //you only want to set the balance after your finish manipulating

            basicResponse.Success = true;
            basicResponse.Amount = amount;                     
            basicResponse.Account = account;
            basicResponse.Balance = account.Balance;

            
            return basicResponse;
        }
    }
}
