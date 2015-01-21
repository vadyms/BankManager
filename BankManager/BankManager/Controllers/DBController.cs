using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankManager.Controllers
{
    public class DBController : Controller
    {
        //
        // GET: /DB/

        public ActionResult Index()
        {
            using (var db = new MainDBEntities())
            {
                return View( db.Clients.ToList() );
            } 
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create( Client client )
        {
            try
            {
                using (var db = new MainDBEntities())
                {
                    db.Clients.Add( client );
                    db.SaveChanges();
                }
                return RedirectToAction( "Index" );
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit( int id )
        {
            MainDBEntities dbcontext = new MainDBEntities();

            using (var db = new MainDBEntities())
            {
                Client client = dbcontext.Clients.Where( x => x.ID == id ).Single();
                return View( client );
            }
        }

        [HttpPost]
        public ActionResult Edit( int id, Client client )
        {
            MainDBEntities dbcontext = new MainDBEntities();
            try
            {
                Client client1 = dbcontext.Clients.Where( x => x.ID == id ).Single();
                client1.FirstName = client.FirstName;
                client1.LastName = client.LastName;
                client1.DateOfBirth = client.DateOfBirth;
                client1.PhoneNumber = client.PhoneNumber;
                client1.StatusID = client.StatusID;
                client1.Deposit = client.Deposit;
                //dbcontext.AcceptAllChanges();
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                  return View();
            }
        }

    }
}
