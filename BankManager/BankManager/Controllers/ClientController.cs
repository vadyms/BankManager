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
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
        public ActionResult Create( BankManager.Models.ClientModel clientModel )
        {
            Client client = new Client();
            if (ModelState.IsValid)
            {
                client.Id = clientModel.Id;
                client.FirstName = clientModel.FirstName;
                client.LastName = clientModel.LastName;
                client.ClientContactNumber = clientModel.ClientContactNumber;
                client.StatusID = clientModel.StatusID;
                client.DateOfBirth = clientModel.DateOfBirth;
                client.PhoneNumber = clientModel.PhoneNumber;
                client.Deposit = clientModel.Deposit;
                _clientService.Create( client );
                return RedirectToAction( "Index" );
            }

            ViewBag.StatusID = new SelectList( _statusService.FindAll(), "Id", "StatusName", client.StatusID );
            return View(clientModel);
        }

        // print table content
        public ActionResult Print()
        {
            logger.Debug("Print html context for clients");

            return View();
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
        public ActionResult Edit(BankManager.Models.ClientModel clientModel)
        {
            Client client=new Client();
            if (ModelState.IsValid)
            {
                client.Id = clientModel.Id;
                client.FirstName = clientModel.FirstName;
                client.LastName = clientModel.LastName;
                client.ClientContactNumber = clientModel.ClientContactNumber;
                client.StatusID = clientModel.StatusID;
                client.DateOfBirth = clientModel.DateOfBirth;
                client.PhoneNumber = clientModel.PhoneNumber;
                client.Deposit = clientModel.Deposit;
                _clientService.Update(client);
                return RedirectToAction("Index");
            }
            return View(clientModel);
        }
    }
}
