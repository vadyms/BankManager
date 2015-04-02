using BankManager.Interfaces;
using BankManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankManager.Controllers
{
    public class ClientController : Controller
    {
        //
        // GET: /Client/
        private readonly IService<Client> _clientService=null;
        private readonly IService<ClientStatus> _statusService = null;

        public ActionResult Index()
        {
            var clients = _clientService.FindAll();
            
            return View( clients );
        }
        public ClientController(IService<Client> clientService, IService<ClientStatus> statusService)
        {
            _statusService = statusService;
            _clientService = clientService;
        }
        public ActionResult Create()
        {
            ViewBag.StatusID = new SelectList( _statusService.FindAll(), "Id", "StatusName" );
            return View( );
        }

        [HttpPost]
        public ActionResult Create( Client client )
        {
            if (ModelState.IsValid)
            {
                _clientService.Create( client );
                return RedirectToAction( "Index" );
            }

            ViewBag.StatusID = new SelectList( _statusService.FindAll(), "Id", "StatusName", client.StatusID );
            return View( client );
        }
        
        //
        // GET: /DBGrid/Details/5

        public ViewResult Details(int id)
        {
            var clients = _clientService.FindAll();
            Client client = clients.FirstOrDefault(u => u.Id == id);
            return View(client);
        }

        //
        // GET: /DBGrid/Edit/5

        public ActionResult Edit(int id)
        {
            var clients = _clientService.FindAll();
            Client client = clients.FirstOrDefault(u => u.Id == id);
            //ClientStatus status = _statusService.FindById(client.StatusID);
            //ViewBag.StatusID = status.StatusName;
            ViewBag.StatusID = new SelectList(_statusService.FindAll(), "ID", "StatusName", client.StatusID);
            return View(client);
        }

        //
        // GET: /DBGrid/Delete/5

        public ActionResult Delete(int id)
        {
            Client client = _clientService.FindById(id);
            return View(client);
        }

        //
        // POST: /DBGrid/Edit/5

        [HttpPost]
        public ActionResult Edit(Client client)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(client).State = EntityState.Modified;
            //    db.SaveChanges();
                return RedirectToAction("Index");
                //}
                //ViewBag.StatusID = new SelectList(.ClientStatuses, "ID", "StatusName", client.StatusID);
                //return View(client);
        }
    }
}
