using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankManager.Models
{
    public partial class BankClientStatus
    {
        public BankClientStatus()
        {
            this.Clients = new HashSet<BankClient>();
        }

        public string StatusName { get; set; }
        public int ID { get; set; }

        public virtual ICollection<BankClient> Clients { get; set; }
    }
}