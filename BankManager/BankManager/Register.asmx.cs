using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace BankManager
{
    /// <summary>
    /// Summary description for Register
    /// </summary>
    [WebService( Namespace = "http://tempuri.org/" )]
    [WebServiceBinding( ConformsTo = WsiProfiles.BasicProfile1_1 )]
    [System.ComponentModel.ToolboxItem( false )]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Register : System.Web.Services.WebService
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType );

        [WebMethod]
        public bool UserRegister( BankManager.Models.RegModel user )
        {
            try
            {
                using (var db = new MainDBEntities())
                {
                    var crypto = new SimpleCrypto.PBKDF2();
                    var encrypPass = crypto.Compute( user.Password );
                    var sysUser = db.Users.Create();
                    sysUser.Login = user.Login;
                    sysUser.Password = encrypPass;
                    sysUser.PasswordSalt = crypto.Salt;
                    sysUser.Email = user.Email;
                    sysUser.Address = user.Address;
                    db.Users.Add( sysUser );
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                logger.Error( "Registration failed for user: " + user.Login + " " +user.Email );
                return false;
            }
        }
    }
}
