using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Moq;
using BankManager;
using BankManager.Models;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Create()
        {
            Client cl = new Client();
            cl.FirstName = "FNtest";
            cl.LastName = "LNtest";
            cl.PhoneNumber = "12341234";
            cl.StatusID = 1;
            cl.ClientContactNumber = 1;
            cl.DateOfBirth = DateTime.Now;
            cl.Deposit = true;
            ClientRepository cr = new ClientRepository();
            cr.Create(cl);
            Assert.AreEqual(1, 1);
        }
    }
}
