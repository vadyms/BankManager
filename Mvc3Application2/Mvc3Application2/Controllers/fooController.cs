using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc3Application2.Controllers
{
    public class fooController : Controller
    {
        //
        // GET: /foo/

        public ActionResult Index()
        {
            return View();
        }

    }
}
