using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BankManager.ServiceLogin;
using BankManager.ServiceRegister;

namespace BankManager.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        readonly log4net.ILog logger = log4net.LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType );

        private LoginSoapClient userLogin;
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
            userLogin = new LoginSoapClient();
            if (ModelState.IsValid)
            {
                if (userLogin.IsValid( user.Login, user.Password ))
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
                ServiceRegister.RegModel user1 = new ServiceRegister.RegModel();
                user1.Login = user.Login;
                user1.Password = user.Password;
                user1.RepeatPassword = user.RepeatPassword;
                user1.Email = user.Email;
                user1.Address = user.Address;

                if (userRegister.UserRegister( user1 ))
                {
                    return RedirectToAction( "Index", "Home" );
                } 
                else
                {
                    // notify about unsuccessful registration
                    ModelState.AddModelError( "", "Registration filed. Please contact admin@BankManager.com for details." );
                }
            } 
            else 
            {
                // notify about incorrect model state
                ModelState.AddModelError( "", "Registration filed. Icorrect registration form." );
            }
            return View();
        }
        
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
    }
}
