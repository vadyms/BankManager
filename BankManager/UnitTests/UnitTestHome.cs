using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankManager.Controllers;
using System.Web.Mvc;

namespace UnitTests
{
    [TestClass]
    public class UnitTestHome
    {
        [TestMethod]
        public void HomeTestMethod()
        {
            // Arrange
            HomeController homeCtrl = new HomeController();

            // Act
            ActionResult res = homeCtrl.Index();

            // Assert
            Assert.IsNotNull(res);
            string s = res.ToString();
        }
    }
}
