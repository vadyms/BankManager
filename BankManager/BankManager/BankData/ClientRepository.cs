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

        public int Update(Client client)
        {
            if (client != null)
            {
                dbContext.Entry(client).State = EntityState.Modified;
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

        IEnumerable<ClientStatus> IRepository<ClientStatus>.FindAll()
        {
            return dbContext.ClientStatuses.ToList();
        }

        ClientStatus IRepository<ClientStatus>.FindById(int id)
        {
            return dbContext.ClientStatuses.Find( id );
        }


        Client IRepository<Client>.FindById(int id)
        {
            return dbContext.Clients.Find(id);
        }


        public int Update(ClientStatus t)
        {
            throw new NotImplementedException();
        }

        int IRepository<Client>.Create(Client t)
        {
            return Create(t);
        }

        int IRepository<Client>.Update(Client t)
        {
            return Update(t);
        }

        IEnumerable<Client> IRepository<Client>.FindAll()
        {
            return FindAll();
        }

        public int Create(ClientStatus t)
        {
            return Create(t);
        }
    }
}