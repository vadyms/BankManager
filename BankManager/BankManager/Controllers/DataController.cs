using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankManager.Controllers
{
    public class DataController : Controller
    {
        //
        // GET: /Data/

        public ActionResult Index()
        {
            var clients = new List<Client>();
            using (var db = new MainDBEntities())
            {
                using (MainDBEntities dc = new MainDBEntities())
                {
                    clients = dc.Clients.ToList();
                }
            }
            return View(clients);
        }

    }
}
