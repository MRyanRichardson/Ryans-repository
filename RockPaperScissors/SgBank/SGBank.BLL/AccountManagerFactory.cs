using System;
using System.Configuration;
using SGBank.Data;

namespace SGBank.BLL
{
    //Static because they are just utility classes. If not Static you have to instantiate later
    // Added system configuration
    public static class AccountManagerFactory
    {
        public static AccountManager Create()
        {
            //App Settings is a dictionary and we are loading the mode key from app settings
            //App settings is in mode. Mode is the key And free test is the value
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "FreeTest":
                    return new AccountManager(new FreeAccountTestRepository());
                case "BasicTest":
                    return new AccountManager(new BasicAccountTestRepository());
                case "PremiumTest":
                    return new AccountManager(new PremiumAccountTestRepository());
                case "FileTest":
                    return new AccountManager(new FileTestRepository(@"C:\SoftwareGuild\SGBank\Data\Accounts.txt"));
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
