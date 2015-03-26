using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BankManager.ServiceRegister;
using BankManager.Abstract;
using Moq;
using Autofac;

namespace BankManager.Controllers
{
    public class UserController : Controller
    {

        //
        // GET: /User/
        readonly log4net.ILog logger = log4net.LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType );

        private RegisterSoapClient userRegister;

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction( "Index", "Home" );
        }

        [HttpPost]
        public ActionResult LogIn(BankManager.Models.UserModel user)
        {
            //userLogin = new LoginSoapClient();
            if (ModelState.IsValid)
            {
                if (IsValid( user.Login, user.Password ))
                {
                    FormsAuthentication.SetAuthCookie( user.Login, false );
                    return RedirectToAction( "Index", "DBGrid" );
                }
                else
                {
                    ModelState.AddModelError("","Login Data is incorrect.");
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Registration( BankManager.Models.RegModel user )
        {
            userRegister = new RegisterSoapClient();
            if (ModelState.IsValid)
            {
                ServiceRegister.RegModel usermodel = new ServiceRegister.RegModel();
                usermodel.Login = user.Login;
                usermodel.Password = user.Password;
                usermodel.RepeatPassword = user.RepeatPassword;
                usermodel.Email = user.Email;
                usermodel.Address = user.Address;
                if (usermodel.Password == usermodel.RepeatPassword)
                {
                    if (userRegister.UserRegister( usermodel ))
                    {
                        ViewBag.Message = "User successfully registerred.";
                        return View();
                        //return RedirectToAction( "Index", "Home" );
                    }
                    else
                    {
                        // notify about unsuccessful registration
                        ModelState.AddModelError( "", "Registration failed. Please contact admin@BankManager.com for details." );
                    }
                }
                else
                {
                    ModelState.AddModelError( "", "Passwords are not the same." );
                }
            } 
            else 
            {
                // notify about incorrect model state
                ModelState.AddModelError( "", "Registration failed. Icorrect registration form." );
            }
            return View();
        }
        
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        private void AddBindings()
        {
            Mock<IUserRepository> mock = new Mock<IUserRepository>();
            mock.Setup(m => m.Users).Returns(new List<User> {
                new User{ID = 1, Login="1", Password= "1", PasswordSalt="1", Email="1@u.com", Address="1 street"}
            }.AsQueryable());
        }

        public bool IsValid(string login, string password)
        {
            bool isValid = false;
            var crypto = new SimpleCrypto.PBKDF2();
            using (var db = new MainDBEntities())
            {
                var user = db.Users.FirstOrDefault(u => u.Login == login);
                if (user != null)
                {
                    if (user.Password == crypto.Compute(password, user.PasswordSalt))
                    {
                        isValid = true;
                    }
                }
            }
            return isValid;
        }

    }
}
