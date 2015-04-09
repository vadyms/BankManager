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
using BankManager.Abstract;
using BankManager.BankData;

namespace UnitTests
{
    [TestClass]
    public class UnitTestClients
    {
        private readonly IService<Client> _clientService = null;
        private readonly IService<ClientStatus> _statusService = null;
        private readonly IRepository<Client> _iClientRepository;
        private readonly IService<User> _userService = null;

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
            Mock<IService<User>> mock = new Mock<IService<User>>();
            mock.Setup(m => m.FindAll()).Returns(new List<User> {
                new User { Id=1, Login="1", Password="1", PasswordSalt="1", Address="1", Email="1@1.com" },
                new User { Id=2, Login="2", Password="2", PasswordSalt="2", Address="2", Email="2@2.com" },
                new User { Id=3, Login="3", Password="3", PasswordSalt="3", Address="3", Email="3@3.com" }
            }.AsQueryable());

            UserController controller = new UserController(mock.Object);
            var result = controller.Index(); ;

            //ClientController clientCrtl = new ClientController(_clientService,_statusService);
            //Assert.AreNotEqual(clientCrtl, null);

            //IWebDriver driver = new InternetExplorerDriver(@"C:\WebDriverSrv");
            //IWebDriver driver = new InternetExplorerDriver();
            //string sUrl = "http://google.com";
            //driver.Navigate().GoToUrl(sUrl);
        }
        [TestMethod]
        public void ClientServiceTestMethod()
        {
            ClientService clServices = new ClientService(_iClientRepository);
            Assert.AreNotEqual(clServices, null);
        }
    }
}

