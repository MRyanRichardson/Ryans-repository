using SGBank.BLL;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgBank.WorkFlows
{
    public class WithdrawWorkFlow
    {
        public void Execute()
        {
            Console.Clear();
            AccountManager account = AccountManagerFactory.Create();

            Console.WriteLine("Make A Withdraw");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Enter an account number: ");
            string accountNumber = Console.ReadLine();

            AccountLookupResponse response = account.LookupAccount(accountNumber);

            if (!response.Success)
            {
                Console.WriteLine("An error occured: ");
                Console.WriteLine(response.Message);
                Console.ReadKey();
                return;
            }

            try
            {
                Console.Write("Enter a withdraw amount: $");
                decimal withdrawAmount = decimal.Parse(Console.ReadLine());
                AccountWithDrawResponse withdrawResponse = account.Withdraw(accountNumber, withdrawAmount);

                if (withdrawResponse.Success)
                {
                    Console.WriteLine("Withdraw Completed!");
                    Console.WriteLine($"Account Number: {withdrawResponse.Account.AccountNumber} ");
                    Console.WriteLine($"Old balance: {withdrawResponse.OldBalance:c} ");
                    Console.WriteLine($"Amount Withdraw: {withdrawResponse.Amount:c} ");
                    Console.WriteLine($"New Balance: {withdrawResponse.Account.Balance:c} ");
                }
                else
                {
                    Console.WriteLine("An error occured: ");
                    Console.WriteLine(withdrawResponse.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured: Invalid Withdraw Amount");
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
