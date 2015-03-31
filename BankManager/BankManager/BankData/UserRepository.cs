using BankManager.Abstract;
using BankManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankManager.BankData
{
    public class UserRepository:IRepository<User>
    {
        private BankDBEntities context = new BankDBEntities();

        public int Create(User user)
        {
            if (user != null)
            {
                context.Users.Add(user);
                context.SaveChanges();
                return 1;
            }
            return 0;
        }

        public IEnumerable<User> FindAll()
        {
            var users = context.Users;
            return users.ToList();
        }

        public User FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}