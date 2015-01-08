using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mvc3Application2.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                //if (model.Username == "Jed" && model.Password == "albao") //Simulate data store
                if (model.Username == "a" && model.Password == "a") //Simulate data store
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    return RedirectToAction("index", "home");
                }
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }
            return View();
        }
    }
}
