using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.Interfaces
{
    public interface IAuthentication
    {
        void Login(string username);
        void Logout();
    }
}
