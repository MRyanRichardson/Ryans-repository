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
    public class PremiumAccountWithdrawRules : IWithDraw
    {
        public AccountWithDrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithDrawResponse pAwr = new AccountWithDrawResponse();

            if (account.Type != AccountType.Premium)
            {
                pAwr.Success = false;
                pAwr.Message = "Error: A non Premium account hit the Premium Withdraw Rule. Contact IT";
                return pAwr;
            }

            if (amount >= 0)
            {
                pAwr.Success = false;
                pAwr.Message = "Withdrawal amounts must be negative!";
                return pAwr;
            }



            pAwr.Amount = amount;// can comment out
            pAwr.OldBalance = account.Balance;//can comment out
            account.Balance += amount;



            //if (account.Balance < -500)
            //{
            //    pAwr.Success = true;
            //    account.Balance -= 10;
            //    pAwr.Balance = account.Balance;
            //    pAwr.Account = account;

            //    return pAwr;
            //}
            if (account.Balance < -500)
            {
                pAwr.Success = false;
                pAwr.Message = "Premium account balance cannot be less than -500!";

                return pAwr;
            }

            pAwr.Success = true;
            pAwr.Amount = amount;
         
          
            pAwr.Account = account;



            return pAwr;
        }

    }
}
