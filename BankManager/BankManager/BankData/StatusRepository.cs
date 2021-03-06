﻿using BankManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankManager.Models
{
    public class StatusRepository : IRepository<ClientStatus>
    {
        BankDBEntities dbContext = new BankDBEntities();

        public int Create( ClientStatus status )
        {
            if (status != null)
            {
                dbContext.ClientStatuses.Add( status );
                dbContext.SaveChanges();
                return 1;
            }
            return 0;
        }

        public IEnumerable<ClientStatus> FindAll()
        {

            return dbContext.ClientStatuses.ToList();
        }

        public ClientStatus FindById( int id )
        {
            return dbContext.ClientStatuses.Find( id );
        }


        public int Update(ClientStatus t)
        {
            throw new NotImplementedException();
        }
    }
}