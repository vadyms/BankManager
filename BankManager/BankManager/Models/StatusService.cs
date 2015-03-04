﻿using BankManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankManager.Models
{
    public class StatusService:IService<ClientStatus>
    {

        private readonly IRepository<ClientStatus> _iStatusRepository;
        public StatusService( IRepository<ClientStatus> iStatusRepository )
        {
            _iStatusRepository = iStatusRepository;
        }
        public int Create( ClientStatus t )
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientStatus> FindAll()
        {
            return _iStatusRepository.FindAll();
        }

        public ClientStatus FindById( int id )
        {
            throw new NotImplementedException();
        }

        public void SendMail()
        {
            throw new NotImplementedException();
        }

        public void CalculateTotalProfit()
        {
            throw new NotImplementedException();
        }
    }
}