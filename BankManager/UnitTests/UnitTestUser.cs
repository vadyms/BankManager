using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankManager.Interfaces;
using BankManager;
using BankManager.Controllers;
using BankManager.Models;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BankManager.Dummies;
using BankManager.BankData;

namespace UnitTests
{
    [TestClass]
    public class UnitTestUser
    {
        User user1 = null;
        User user2 = null;
        User user3 = null;
        
        List<User> users = null;
        UserDummyRepository usersRepo = null;
        UserController uctrl = null;

        UserRepository userRepository;

        public UnitTestUser()
        {
            // Lets create some sample users
            user1 = new User { Id = 1, Login = "1", Password = "1", PasswordSalt = "1", Address = "1", Email = "1@1.com" };
            user2 = new User { Id = 2, Login = "2", Password = "2", PasswordSalt = "2", Address = "2", Email = "2@2.com" };
            user3 = new User { Id = 3, Login = "3", Password = "3", PasswordSalt = "3", Address = "3", Email = "3@3.com" };

            users = new List<User>
                {
                    user1,
                    user2,
                    user3,
                };

            //BankDBEntities context=new BankDBEntities(){
            //    Users= users,
            //    Clients=null,
            //    ClientStatuses=null
            //};

            //userRepository = new UserRepository(context);

            // Lets create our dummy repository
            usersRepo = new UserDummyRepository(users);
        }



        [TestMethod]
        public void ClientControllerTest()
        {
            User user1;

            Mock<IService<User>> mock = new Mock<IService<User>>();
            mock.Setup(m => m.FindAll()).Returns(new List<User> {
                new User { Id=1, Login="1", Password="1", PasswordSalt="1", Address="1", Email="1@1.com" },
                new User { Id=2, Login="2", Password="2", PasswordSalt="2", Address="2", Email="2@2.com" },
                new User { Id=3, Login="3", Password="3", PasswordSalt="3", Address="3", Email="3@3.com" }
            }.AsQueryable());

            UserController controller = new UserController(mock.Object);
            var result = controller.Index();
            ActionResult result1 = controller.Index();
        }
    }
}
