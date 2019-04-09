using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL
{
    public class AccountManager
    {
        //public class Account
        //{
        //    public string Name { get; set; }
        //    public string AccountNumber { get; set; }
        //    public decimal Balance { get; set; }
        //    public AccountType Type { get; set; }
        //}

        //This has load and save account in it
        private IAccountRepository _accountRepository;
        // setting this to what we pass into accountRepository


        //setting our load and save account to account repository
        // dependency injection
        public AccountManager(IAccountRepository accountRepository)// passing in our testrepositories
        {
            _accountRepository = accountRepository;
        }

        //gets and sets our account then will let us know if we have a valid account or not
        public AccountLookupResponse LookupAccount(string accountNumber)
        {
            //instantiates lookup response which has our get set message and success
            AccountLookupResponse response = new AccountLookupResponse();

            response.Account = _accountRepository.LoadAccount(accountNumber);

            if (response.Account == null)
            {
                response.Success = false;
                response.Message = $"{accountNumber} is not a valid account";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public AccountDepositResponse Deposit(string accountNumber, decimal amount)
        {

            AccountDepositResponse response = new AccountDepositResponse();

            // Utilizing free basic or premium account
            response.Account = _accountRepository.LoadAccount(accountNumber);

            if (response.Account == null)
            {
                response.Success = false;
                response.Message = $"{accountNumber} is not a valid account";
            }
            else
            {
                response.Success = true;
            }

            // This is where we take the response of the account type and deposit it into the responsed account
            IDeposit depositRule = DepositRulesFactory.Create(response.Account.Type);
            response = depositRule.Deposit(response.Account, amount);
            if (response.Success)
            {
                _accountRepository.SaveAccount(response.Account);
            }
            return response;
        }

        public AccountWithDrawResponse Withdraw(string accountNumber, decimal amount)
        {
            AccountWithDrawResponse awr = new AccountWithDrawResponse();
           
            awr.Account = _accountRepository.LoadAccount(accountNumber);

            if (awr.Account == null)
            {
                awr.Success = false;
                awr.Message = $"{accountNumber} is not a valid account";
            }
            else
            {
                awr.Success = true;
            }

            IWithDraw withdrawRule = WithDrawRulesFactory.Create(awr.Account.Type);

            awr = withdrawRule.Withdraw(awr.Account, amount);
            if (awr.Success)
            {
                _accountRepository.SaveAccount(awr.Account);
            }
            return awr;
            


        }
        

    }
}
