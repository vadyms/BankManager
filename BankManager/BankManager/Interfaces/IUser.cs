using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankManager.Interfaces
{
    interface IUser
    {
        string Login { get; set; }
        string Password { get; set; }
        string Email { get; set; }
        void Add();
    }
}
