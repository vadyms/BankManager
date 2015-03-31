using BankManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankManager.Services
{
    public class UserService:IService<User>
    {
        private readonly IRepository<User> _iUserRepository;
        public int Create(User t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> FindAll()
        {
            return _iUserRepository.FindAll();
        }

        public User FindById(int id)
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