using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankManager.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
    }
}
