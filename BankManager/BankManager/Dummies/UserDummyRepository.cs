using BankManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankManager.Dummies
{
    public class UserDummyRepository : IRepository<User>
    {
        static User user1 = new User { Id = 1, Login = "1", Password = "9rR6HfwLsqmp8X//uJ14mB0Dyf/112YTrXyrOH4xQv8sfDwizpV8oiq+z3+QipGYKPC1/9/ApECvQdKFTfokNA==", PasswordSalt = "100000.aOJV9h5ULYE0qRwyadwejNchy2Ar4BbfY7DaMryzbcQYMw==", Address = "1", Email = "1@1.com" };
        static User user2 = new User { Id = 2, Login = "2", Password = "2", PasswordSalt = "2", Address = "2", Email = "2@2.com" };
        static User user3 = new User { Id = 3, Login = "3", Password = "3", PasswordSalt = "3", Address = "3", Email = "3@3.com" };
        List<User> m_users = new List<User>
                {
                    user1,
                    user2,
                    user3,
                };

        public int Create(User t)
        {
            try
            {
                m_users.Add(t);
                return 0;
            }
            catch
            {
                return 1;
            }
            
        }

        public int Update(User t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> FindAll()
        {
            return m_users;
        }

        public User FindById(int id)
        {
            throw new NotImplementedException();
        }

        int IRepository<User>.Create(User t)
        {
            throw new NotImplementedException();
        }

        int IRepository<User>.Update(User t)
        {
            throw new NotImplementedException();
        }

        IEnumerable<User> IRepository<User>.FindAll()
        {
            return m_users;
        }

        User IRepository<User>.FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}