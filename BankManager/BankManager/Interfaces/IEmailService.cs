using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.Interfaces
{
    public interface IEmailService
    {
        int SendEmail(string from, string to, string subject, string context);
    }
}
