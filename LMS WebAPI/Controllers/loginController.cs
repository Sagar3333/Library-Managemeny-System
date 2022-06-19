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
        public IHttpActionResult Index(login login)
        {
            return Redirect(
            Url.Link("DefaultApi",
                new
                {
                    httproute = "",
                    controller = "login",
                    action = "AuthenticateUser",
                    id = login.email,
                    id2 = login.password
                }));
        }

        [Route("api/AuthenticateUser")]
        [HttpGet]
        public string AuthenticateUser([FromUri] string id, [FromUri] byte id2)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommandWrapperEmail = db.GetSqlStringCommand("select email, [password] from [user] where email = '" + id + "'");
            DbCommand dbCommandWrapperEmailAndPassword = db.GetSqlStringCommand("select email, [password] from [user] where email = '" + id + "' and [password] = " + id2);
            var dsEmail = db.ExecuteDataSet(dbCommandWrapperEmail);
            var dsEmailAndPassword = db.ExecuteDataSet(dbCommandWrapperEmailAndPassword);

            if (dsEmail == null)
            {
                return "you are not registered";
            }
            else if (dsEmailAndPassword == null)
            {
                return "password is incorrect";
            }
            else
            {
                return "login successfull";
            }
        }
    }
}
