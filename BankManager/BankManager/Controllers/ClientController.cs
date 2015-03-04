﻿using BankManager.Interfaces;
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

        public ClientController( IService<Client> clientService,  IService<ClientStatus> statusService)
        {
            _clientService = clientService;
            _statusService = statusService;
        }

        public ActionResult Index()
        {
            var clients = _clientService.FindAll();
            
            return View( clients );
        }
        public ActionResult Create()
        {
            ViewBag.StatusID = new SelectList( _statusService.FindAll(), "ID", "StatusName" );
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

            ViewBag.StatusID = new SelectList( _statusService.FindAll(), "ID", "StatusName", client.StatusID );
            return View( client );
        }
    }
}