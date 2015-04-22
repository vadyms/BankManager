using BankManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankManager.Dummies
{
    public class StatusDummyRepository : IRepository<ClientStatus>
    {
        public int Create(ClientStatus t)
        {
            throw new NotImplementedException();
        }

        public int Update(ClientStatus t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientStatus> FindAll()
        {
            throw new NotImplementedException();
        }

        public ClientStatus FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}