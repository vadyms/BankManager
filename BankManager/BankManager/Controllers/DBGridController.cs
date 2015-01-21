using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankManager;

namespace BankManager.Controllers
{ 
    public class DBGridController : Controller
    {
        private MainDBEntities db = new MainDBEntities();


        public JsonResult GetEmployees()
        {
            var dbResult = db.Clients.ToList();
            var clients = (from client in dbResult
                             select new
                             {
                                 client.ID,
                                 client.ClientContactNumber,
                                 client.FirstName,
                                 client.LastName,
                                 client.DateOfBirth,
                                 client.PhoneNumber,
                                 client.Deposit,
                                 client.ClientStatus.StatusName
                             });
            return Json( clients, JsonRequestBehavior.AllowGet );
        }

        //
        // GET: /DBGrid/

        public ViewResult Index()
        {
            var clients = db.Clients.Include(c => c.ClientStatus);
            return View(clients.ToList());
        }

        //
        // GET: /DBGrid/Details/5

        public ViewResult Details(int id)
        {
            Client client = db.Clients.Find(id);
            return View(client);
        }

        //
        // GET: /DBGrid/Create

        public ActionResult Create()
        {
            ViewBag.StatusID = new SelectList(db.ClientStatuses, "ID", "StatusName");
            return View();
        } 

        //
        // POST: /DBGrid/Create

        [HttpPost]
        public ActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.StatusID = new SelectList(db.ClientStatuses, "ID", "StatusName", client.StatusID);
            return View(client);
        }
        
        //
        // GET: /DBGrid/Edit/5
 
        public ActionResult Edit(int id)
        {
            Client client = db.Clients.Find(id);
            ViewBag.StatusID = new SelectList(db.ClientStatuses, "ID", "StatusName", client.StatusID);
            return View(client);
        }

        //
        // POST: /DBGrid/Edit/5

        [HttpPost]
        public ActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StatusID = new SelectList(db.ClientStatuses, "ID", "StatusName", client.StatusID);
            return View(client);
        }

        //
        // GET: /DBGrid/Delete/5
 
        public ActionResult Delete(int id)
        {
            Client client = db.Clients.Find(id);
            return View(client);
        }

        //
        // POST: /DBGrid/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}