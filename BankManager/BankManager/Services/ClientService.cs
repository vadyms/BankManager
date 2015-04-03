using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;
using BankManager.Interfaces;

namespace BankManager.Models
{
    public class ClientService : IService<Client>
    {
        private readonly IRepository<Client> _iClientRepository;
        public ClientService(IRepository<Client> clientRepository)
        {
            _iClientRepository = clientRepository;
        }
        public int Create( Client client )
        {
            return _iClientRepository.Create( client );
        }

        public IEnumerable<Client> FindAll()
        {
            return _iClientRepository.FindAll();
        }

        public Client FindById( int id )
        {
            return _iClientRepository.FindById( id );
        }

        public int Create( ClientStatus t )
        {
            throw new NotImplementedException();
        }


        public int Update(Client client)
        {
            return _iClientRepository.Update(client);
        }
    }
}