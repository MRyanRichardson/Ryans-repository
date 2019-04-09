using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SGBank.Models;
using SGBank.Models.Interfaces;

namespace SGBank.Data
{
    public class FileTestRepository : IAccountRepository
    {

        public string _filePath { get; set; }


        public FileTestRepository(string filepath)
        {
            _filePath = filepath;

        }

        public List<Account> List()
        {
            List<Account> _accounts = new List<Account>();
            using (StreamReader sr = new StreamReader(_filePath))
            {
                sr.ReadLine();// header line
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] s = line.Split(',');

                    Account acct = new Account();
                    switch (s[3].ToUpper())
                    {
                        case "F":
                            acct.Type = AccountType.Free;
                            break;
                        case "B":
                            acct.Type = AccountType.Basic;
                            break;
                        case "P":
                            acct.Type = AccountType.Premium;
                            break;
                        default:
                            break;
                    }
                    acct.AccountNumber = s[0];
                    acct.Name = s[1];
                    acct.Balance = Convert.ToDecimal(s[2]);
                    _accounts.Add(acct);
                }
            }
            return _accounts;
        }

        public Account LoadAccount(string accountNumber)
        {
            List<Account> _accounts = List();
            // var account needs to be plural (accounts)
            var account = _accounts.Where(a => a.AccountNumber == accountNumber).ToArray(); 
            if(account.Count() == 0)
            {
                return null;
            }
            else
            {                
            Account rtnAcct = new Account();
            rtnAcct.AccountNumber = account[0].AccountNumber;
            rtnAcct.Name = account[0].Name;
            rtnAcct.Balance = account[0].Balance;
            rtnAcct.Type = account[0].Type;
            return rtnAcct;
            }
        }

        public void SaveAccount(Account account)
        {
            List<Account> _accounts = List();
            //need to be using for streamwriter
            StreamWriter sw = new StreamWriter(_filePath);
            string aType = "";
            //Write Header
            sw.WriteLine($"AccountNumber,Name,Balance,Type");
            foreach (Account a in _accounts)
            {
                if (a.AccountNumber == account.AccountNumber)
                {
                    a.Balance = account.Balance;
                }
                switch (a.Type)
                {
                    case AccountType.Free:
                        aType = "F";
                        break;
                    case AccountType.Basic:
                        aType = "B";
                        break;
                    case AccountType.Premium:
                        aType = "P"; ;
                        break;
                    default:
                        break;
                }
                sw.WriteLine($"{a.AccountNumber},{a.Name},{a.Balance},{aType}");
            }
            sw.Close();
        }
    }
}
