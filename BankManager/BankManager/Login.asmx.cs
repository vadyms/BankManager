using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace BankManager
{
    /// <summary>
    /// Summary description for Login
    /// </summary>
    [WebService( Namespace = "http://tempuri.org/" )]
    [WebServiceBinding( ConformsTo = WsiProfiles.BasicProfile1_1 )]
    [System.ComponentModel.ToolboxItem( false )]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Login : System.Web.Services.WebService
    {

        [WebMethod]
        public bool IsValid( string login, string password )
        {
            bool isValid = false;
            var crypto = new SimpleCrypto.PBKDF2();
            using (var db = new MainDBEntities())
            {
                var user = db.Users.FirstOrDefault( u => u.Login == login );
                if (user != null)
                {
                    if (user.Password == crypto.Compute( password, user.PasswordSalt ))
                    {
                        isValid = true;
                    }
                }
            }
            return isValid;
        }
    }
}
