using BankManager.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankManager.BankData
{
    public class UserRepository:IUserRepository
    {
        private BankDBEntities context = new BankDBEntities();
        public IQueryable<User> Users
        {
            get { return context.Users; }
        }
    }
}