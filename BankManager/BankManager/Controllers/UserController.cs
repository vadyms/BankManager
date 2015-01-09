using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BankManager.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

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
                    return RedirectToAction( "Index", "DATA" );
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
                using (var db = new MainDBEntities())
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
                    return RedirectToAction( "Index", "Home" );
                } 
            }else {

            }
            return View();
        }
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        private bool IsValid(string login, string password) 
        {
            bool isValid = false;
            var crypto = new SimpleCrypto.PBKDF2();
            using (var db = new MainDBEntities())
            {
                var user = db.Users.FirstOrDefault( u => u.Login == login );
                if (user != null)
                {
                    if (user.Password==crypto.Compute(password,user.PasswordSalt))
                    {
                        isValid=true;
                    }
                }
            }
            return isValid;
        }
    }
}
