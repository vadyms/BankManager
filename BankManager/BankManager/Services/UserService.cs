using BankManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankManager.Services
{
    public class UserService:IService<User>
    {
        private BankDBEntities context = new BankDBEntities();
        public int Create(User t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> FindAll()
        {
            return context.Users;
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