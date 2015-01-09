using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BankManager.Controllers
{
    public class RegistrationController : Controller
    {
        //
        // GET: /Registration/

        public ActionResult Index()
        {
            return View();
        }
        private bool IsValid( string login, string password )
        {
            bool isValid = false;
            var crypto = new SimpleCrypto.PBKDF2();
            using (var db = new MainDBEntities())
            {
                var user = db.Users.FirstOrDefault( u => u.Login == login );
                if (user != null)
                {
                    if (user.Password == crypto.Compute( password, user.PasswordSalt ))
                    {
                        isValid = true;
                    }
                }
            }
            return isValid;
        }

    }
}
