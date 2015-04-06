using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Moq;
using BankManager;
using BankManager.Models;
using BankManager.Controllers;
using BankManager.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace UnitTests
{
    [TestClass]
    public class UnitTestClients
    {
        private readonly IService<Client> _clientService = null;
        private readonly IService<ClientStatus> _statusService = null;
        private readonly IRepository<Client> _iClientRepository;

        [TestMethod]
        public void CreateTestMethod()
        {
            Client cl = new Client();
            cl.FirstName = "FNtest";
            cl.LastName = "LNtest";
            cl.PhoneNumber = "12341234";
            cl.StatusID = 1;
            cl.ClientContactNumber = 1;
            cl.DateOfBirth = DateTime.Now;
            cl.Deposit = true;
            Assert.AreNotEqual(cl, null);

            ClientRepository cr = new ClientRepository();
            //cr.Create(cl);
            Assert.AreNotEqual(cr, null);
        }
        [TestMethod]
        public void ClientControllerTest()
        {
            //IWebDriver driver = new InternetExplorerDriver(@"C:\WebDriverSrv");
            IWebDriver driver = new InternetExplorerDriver();
            string sUrl = "http://google.com";
            driver.Navigate().GoToUrl(sUrl);
            //ClientController clientCrtl = new ClientController(_clientService,_statusService);
            //Assert.AreNotEqual(clientCrtl, null);

        }
        [TestMethod]
        public void ClientServiceTestMethod()
        {
            ClientService clServices = new ClientService(_iClientRepository);
            Assert.AreNotEqual(clServices, null);
        }
    }
}

