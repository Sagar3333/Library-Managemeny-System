using LMS_WebAPI.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LMS_WebAPI.Controllers
{
    public class loginController : ApiController
    {
        [Route("api/login")]
        [HttpPost]
        public /*IHttpActionResult*/ string AuthenticateUser(login login)
        {
            var email = login.email;
            var password = login.password;
            Boolean isAdmin;
            var loginStatus = "";
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommandWrapperEmail = db.GetSqlStringCommand("select email from [user] where email = '" + email + "'");
            DbCommand dbCommandWrapperEmail_Password_isAdmin = db.GetSqlStringCommand("select email, [password], isAdmin from [user] where email = '" + email + "' and [password] = ISNULL(CONVERT(varbinary(256), '" + password + "'), 0x);");
            var dsEmail = db.ExecuteDataSet(dbCommandWrapperEmail);
            var dsEmail_Password_IsAdmin = db.ExecuteDataSet(dbCommandWrapperEmail_Password_isAdmin);
            try
            {
                Convert.ToString(dsEmail.Tables[0].Rows[0]["email"]);
            }
            catch (System.IndexOutOfRangeException)
            {
                loginStatus = "you are not registered";
            }
            if (loginStatus != "you are not registered")
            {
                try
                {
                    Convert.ToString(dsEmail_Password_IsAdmin.Tables[0].Rows[0]["email"]);
                }
                catch (System.IndexOutOfRangeException)
                {
                    loginStatus = "password is incorrect";
                }
            }
            

            if (loginStatus == "you are not registered")
            {
                return "you are not registered";
            }
            else if (loginStatus == "password is incorrect")
            {
                return "password is incorrect";
            }
            else
            {
                isAdmin = Convert.ToBoolean(dsEmail_Password_IsAdmin.Tables[0].Rows[0]["isAdmin"]);
                return isAdmin.ToString();
            }
        }
    }
}
