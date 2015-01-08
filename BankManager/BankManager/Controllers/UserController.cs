using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        [HttpPost]
        public ActionResult LogIn(BankManager.Models.UserModel user)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Registration(BankManager.Models.UserModel user )
        {
            return View();
        }

    }
}
