// <copyright file="ConsoleReadTest.cs" company="Hewlett-Packard">Copyright © Hewlett-Packard 2019</copyright>
using System;
using FlooringMastery;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlooringMastery.Tests
{
    /// <summary>This class contains parameterized unit tests for ConsoleRead</summary>
    [PexClass(typeof(ConsoleRead))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class ConsoleReadTest
    {
        /// <summary>Test stub for checkCustomerName(String)</summary>
        [PexMethod]
        public bool checkCustomerNameTest(string customerName)
        {
            bool result = ConsoleRead.checkCustomerName(customerName);
            return result;
            // TODO: add assertions to method ConsoleReadTest.checkCustomerNameTest(String)
        }
    }
}
