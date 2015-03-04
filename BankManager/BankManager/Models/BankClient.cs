using BankManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankManager
{
    public class BankClient
    {
        public double ClientContactNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public bool Deposit { get; set; }
        public int StatusID { get; set; }
        public int ID { get; set; }

        public virtual BankClientStatus BankClientStatus { get; set; }
    }
}