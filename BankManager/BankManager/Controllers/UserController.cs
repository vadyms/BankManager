using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BankManager.Abstract;
using Moq;
using Autofac;
using BankManager.Interfaces;

namespace BankManager.Controllers
{
    public class UserController : Controller
    {

        //
        // GET: /User/
        readonly log4net.ILog logger = log4net.LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType );
        private readonly IService<User> _userService = null;

        public UserController(IService<User> userService)
        {
            _userService = userService;
        }

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
            if (ModelState.IsValid)
            {
                if (IsValid( user.Login, user.Password ))
                {
                    FormsAuthentication.SetAuthCookie( user.Login, false );
                    return RedirectToAction( "Index", "Client" );
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
            if (ModelState.IsValid)
            {
                user.Login = user.Login;
                user.Password = user.Password;
                user.RepeatPassword = user.RepeatPassword;
                user.Email = user.Email;
                user.Address = user.Address;
                User _user = new User();
                _user.Login = user.Login;
                _user.Password = user.Password;
                _user.Address = user.Address;
                _user.Email = user.Email;
                if (user.Password == user.RepeatPassword)
                {
                    if (_userService.Create( _user ) == 0 )
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

        public bool IsValid(string login, string password)
        {
            bool isValid = false;
            var crypto = new SimpleCrypto.PBKDF2();
            using (var db = new BankDBEntities())
            {
                var users = _userService.FindAll();
                var user = users.FirstOrDefault(u => u.Login == login);
                
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
        public bool UserRegister( BankManager.Models.RegModel user )
        {
            try
            {
                using (var db = new BankDBEntities())
                {
                    var crypto = new SimpleCrypto.PBKDF2();
                    var encrypPass = crypto.Compute( user.Password );
                    var sysUser = db.Users.Create();
                    sysUser.Login = user.Login;
                    sysUser.Password = encrypPass;
                    sysUser.PasswordSalt = crypto.Salt;
                    sysUser.Email = user.Email;
                    sysUser.Address = user.Address;
                    db.Users.Add( sysUser );
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                logger.Error( "Registration failed for user: " + user.Login + " " +user.Email );
                return false;
            }
        }
        private void AddBindings()
        {
            Mock<IUserRepository> mock = new Mock<IUserRepository>();
            mock.Setup(m => m.Users).Returns(new List<User> {
                new User{Id = 1, Login="1", Password= "1", PasswordSalt="1", Email="1@u.com", Address="1 street"}
            }.AsQueryable());
        }
    }
}
