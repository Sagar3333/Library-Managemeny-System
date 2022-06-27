using LMS_WebAPI.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LMS_WebAPI.Controllers
{
    public class userLandingPageController : ApiController
    {
        //[Route("api/addToCart/{email}")]
        //[HttpPost]
        //public void addToCart(topBooks topBooks, string email)
        [Route("api/addToCart/{id}")]
        [HttpPost]
        public string addToCart(int id, string email)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommandWrapper = db.GetSqlStringCommand("select email,id from [user] where email = '" + email + "'");
            var ds = db.ExecuteDataSet(dbCommandWrapper);
            var userId = Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);

            DbCommand dbCommandWrapperProc = db.GetStoredProcCommand("assignBookToUser");

            db.AddInParameter(dbCommandWrapperProc, "@userId", DbType.Int32, userId);
            db.AddInParameter(dbCommandWrapperProc, "@id", DbType.Int32, id);
            db.ExecuteScalar(dbCommandWrapperProc);
            return "Success";
        }
    }
}
