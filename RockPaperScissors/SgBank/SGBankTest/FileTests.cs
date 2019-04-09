using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGBank.BLL;
using SGBank.Models.Responses;

namespace SGBankTest
    // only testing to make sure i can pull back free basic or premium
{
    [TestFixture]
    class FileTests
    {
        //****************************************************************************************************************
        //Free Account Tests
        [Test]

        public void CanLoadFreeAccountTestData()
        {
            AccountManager manager = AccountManagerFactory.Create();
            AccountLookupResponse response = manager.LookupAccount("11111");
            Assert.IsNotNull(response.Account);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("11111", response.Account.AccountNumber);
        }

       

        //****************************************************************************************************************
        //Basic Account Tests
        [Test]
        public void CanLoadBasicAccountTestData()
        {
            AccountManager manager = AccountManagerFactory.Create();
            AccountLookupResponse response = manager.LookupAccount("22222");
            Assert.IsNotNull(response.Account);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("22222", response.Account.AccountNumber);
        }

        //****************************************************************************************************************
        //Premium Test
        [Test]
        public void CanLoadPremiumAccountData()
        {
            AccountManager manager = AccountManagerFactory.Create();
            AccountLookupResponse response = manager.LookupAccount("33333");
            Assert.IsNotNull(response.Account);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("33333", response.Account.AccountNumber);
        }
        
    }
}
