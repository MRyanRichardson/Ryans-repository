using SGBank.BLL;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgBank.WorkFlows
{
    public class DepositWorkflow
    {
        

        public void Execute()
        {
           Console.Clear();

           AccountManager accountManager = AccountManagerFactory.Create();
    
            Console.WriteLine("Make A Deposit");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Enter an account number: ");
            string accountNumber = Console.ReadLine();

            AccountLookupResponse accountResponse = accountManager.LookupAccount(accountNumber);
            if (!accountResponse.Success)
            {
                Console.WriteLine("An error occured: ");
                Console.WriteLine(accountResponse.Message);
                Console.ReadKey();
                return;
            }

            try
            {
                Console.Write($"Enter a deposit amount: $ ");
                decimal amount = decimal.Parse(Console.ReadLine());
                AccountDepositResponse response = accountManager.Deposit(accountNumber, amount);
                if (response.Success)
                {
                    Console.WriteLine("Deposit Completed!");
                    Console.WriteLine($"Account Number: {response.Account.AccountNumber} ");
                    Console.WriteLine($"Old balance: {response.OldBalance:c} ");
                    Console.WriteLine($"Amount Deposited: {response.Amount:c} ");
                    Console.WriteLine($"New Balance: {response.Account.Balance:c} ");
                }
                else
                {
                    Console.WriteLine("An error occured: ");
                    Console.WriteLine(response.Message);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occured: Invalid Deposit Amount");
      
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
