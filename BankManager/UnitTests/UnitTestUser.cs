using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankManager.Interfaces;
using BankManager;
using BankManager.Controllers;
using BankManager.Models;
using Moq;
using Moq.AutoMock;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BankManager.Dummies;
using BankManager.BankData;
using Autofac;
using BankManager.Services;
using Autofac.Integration.Mvc;
using System.Web.Routing;
using System.Web;
using Subtext.TestLibrary;

namespace UnitTests
{

    [TestClass]
    public class UnitTestUser
    {
        private readonly IService<User> _userService = null;
        private IDependencyResolver _originalResolver = null;
        
        private Mock<IService<User>> _mockRepo;
        private UserController userController;


        private HttpSimulator _httpSimulator;


        [TestMethod]
        public void UnitTestUserController1()
        {
            IService<User> _service;
            //Mock<IContext> _mockContext;
            //Mock<DbSet<Country>> _mockSet;
            IQueryable<User> listUser;

            listUser = new List<User>() {
                      new User() { Id = 1, Login = "1" },
                      new User() { Id = 2, Login = "India" }
                     }.AsQueryable();

            //_mockSet = new Mock<DbSet<Country>>();
            //_mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(listUser.Provider);
            //_mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(listUser.Expression);
            //_mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(listUser.ElementType);
            //_mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(listUser.GetEnumerator());

            //_mockContext = new Mock<IContext>();
            //_mockContext.Setup(c => c.Set<Country>()).Returns(_mockSet.Object);
            //_mockContext.Setup(c => c.Countries).Returns(_mockSet.Object);

            //_service = new CountryService(_mockContext.Object);


            var builder = new ContainerBuilder();
            builder.RegisterType(typeof(UserService)).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType(typeof(UserDummyRepository)).AsImplementedInterfaces().InstancePerLifetimeScope();
            
            var container = builder.Build();

            Mock<IRepository<User>> repositoryMock = new Mock<IRepository<User>>();
            //repositoryMock.Setup((m) => m.FindAll()).Returns(expectedPosts);

            var resolver = new AutofacWebApiDependencyResolver(container);
            config.DependencyResolver = resolver;


            try { 
                //DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); //does not work in unit test
            }
            catch
                {
                Console.WriteLine("Can't resolve dependency.");
            }

            //RegisterGlobalFilters(GlobalFilters.Filters);
            //RegisterRoutes(RouteTable.Routes);
            _mockRepo = new Mock<IService<User>>();
            userController = new UserController(_mockRepo.Object);
            //_mockRepo.Setup(mr => mr.FindAll()).Returns(new ValidObject());

            userController = new UserController(_userService);
            UserModel user = new UserModel();
            user.Login = "1";
            user.Password = "1";
            userController.LogIn(user);
            var ss = userController.Index() as ViewResult;
        }



        [TestMethod]
        public void UnitTestUserController2()
        {
            Mock<IService<User>> mock = new Mock<IService<User>>();
            mock.Setup(m => m.FindAll()).Returns(new List<User> {
                new User { Id=1, Login="1", Password="9rR6HfwLsqmp8X//uJ14mB0Dyf/112YTrXyrOH4xQv8sfDwizpV8oiq+z3+QipGYKPC1/9/ApECvQdKFTfokNA==", PasswordSalt="100000.aOJV9h5ULYE0qRwyadwejNchy2Ar4BbfY7DaMryzbcQYMw==", Address="1", Email="1@1.com" },
                new User { Id=2, Login="2", Password="2", PasswordSalt="2", Address="2", Email="2@2.com" },
                new User { Id=3, Login="3", Password="3", PasswordSalt="3", Address="3", Email="3@3.com" }
            }.AsQueryable());

            UserController controller = new UserController(mock.Object);

            var result = controller.Index();
            ActionResult result1 = controller.Index();
            UserModel userLogin = new UserModel();
            userLogin.Login = "1";
            userLogin.Password = "1";

            ActionResult result2 = controller.LogIn(userLogin);
        }
        [TestMethod]
        public void UnitTestUserController3()
        {
            Mock<IService<User>> mock = new Mock<IService<User>>();
            mock.Setup(m => m.FindAll()).Returns(new List<User> {
                new User { Id=1, Login="1", Password="9rR6HfwLsqmp8X//uJ14mB0Dyf/112YTrXyrOH4xQv8sfDwizpV8oiq+z3+QipGYKPC1/9/ApECvQdKFTfokNA==", PasswordSalt="100000.aOJV9h5ULYE0qRwyadwejNchy2Ar4BbfY7DaMryzbcQYMw==", Address="1", Email="1@1.com" },
                new User { Id=2, Login="2", Password="2", PasswordSalt="2", Address="2", Email="2@2.com" },
                new User { Id=3, Login="3", Password="3", PasswordSalt="3", Address="3", Email="3@3.com" }
            }.AsQueryable());

            UserController controller = new UserController(mock.Object);

            var result = controller.Index();
            ActionResult result1 = controller.Index();
            UserModel userLogin = new UserModel();
            userLogin.Login = "";
            userLogin.Password = "";

            ActionResult result2 = controller.LogIn(userLogin);
        }
    }
}
