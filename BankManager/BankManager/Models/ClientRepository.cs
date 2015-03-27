using BankManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;

namespace BankManager.Models
{
    public class ClientRepository : IRepository<Client>, IRepository<ClientStatus>
    {
        // Define DB context to get data
        BankDBEntities dbContext = new BankDBEntities();

        public int Create( Client client )
        {
            if (client != null)
            {
                dbContext.Clients.Add( client );
                dbContext.SaveChanges();
                return 1;
            }
            return 0;
        }
        public IEnumerable<ClientStatus> FindAllStatus()
        {
            return dbContext.ClientStatuses.ToList();
        }
        public IEnumerable<Client> FindAll()
        {
            var clients = dbContext.Clients.Include( c => c.ClientStatus );
            return clients.ToList();
        }

        public Client FindById( int id )
        {
            return dbContext.Clients.Find( id );
        }

        public int Create( ClientStatus t )
        {
            throw new NotImplementedException();
        }

        IEnumerable<ClientStatus> IRepository<ClientStatus>.FindAll()
        {
            return dbContext.ClientStatuses.ToList();
        }

        ClientStatus IRepository<ClientStatus>.FindById( int id )
        {
            throw new NotImplementedException();
        }
    }
}