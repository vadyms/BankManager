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
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public int Create(User user)
        {
            try {
                if (user != null)
                {
                    var crypto = new SimpleCrypto.PBKDF2();
                    var encrypPass = crypto.Compute(user.Password);
                    user.Password = encrypPass;
                    user.PasswordSalt = crypto.Salt;
                    context.Users.Add(user);
                    context.SaveChanges();
                    return 0;
                }
                return 1;
            }
            catch
            {
                logger.Error( "Registration failed for user: " + user.Login + " " +user.Email );
                return 1;
            }
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