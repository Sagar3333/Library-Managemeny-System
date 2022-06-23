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
    public class registrationController : ApiController
    {
        //public IHttpActionResult CreateBook()
        //{
        //    ViewBag.Title = "Home Page";

        //    return View();
        //}

        [Route("api/registrationPage")]
        [HttpPost]
        public IHttpActionResult Index(registration registration)
        {
            //Sending user data to MSSQL database
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommandWrapper = db.GetStoredProcCommand("addUser");

            db.AddInParameter(dbCommandWrapper, "@name", DbType.String, registration.name);
            db.AddInParameter(dbCommandWrapper, "@email", DbType.String, registration.email);
            db.AddInParameter(dbCommandWrapper, "@phone", DbType.String, registration.phone);
            db.AddInParameter(dbCommandWrapper, "@fathersName", DbType.String, registration.fathersName);
            db.AddInParameter(dbCommandWrapper, "@gender", DbType.Boolean, registration.gender);
            db.AddInParameter(dbCommandWrapper, "@governmentIdType", DbType.Int32, registration.governmentIdType);
            db.AddInParameter(dbCommandWrapper, "@governmentId", DbType.String, registration.governmentId);
            db.AddInParameter(dbCommandWrapper, "@dob", DbType.Date, registration.dob);
            db.AddInParameter(dbCommandWrapper, "@address1", DbType.String, registration.address1);
            db.AddInParameter(dbCommandWrapper, "@address2", DbType.String, registration.address2);
            db.AddInParameter(dbCommandWrapper, "@city", DbType.String, registration.city);
            db.AddInParameter(dbCommandWrapper, "@state", DbType.String, registration.state);
            db.AddInParameter(dbCommandWrapper, "@pin", DbType.String, registration.pin);
            db.AddInParameter(dbCommandWrapper, "@password", DbType.String, registration.password);
            db.AddInParameter(dbCommandWrapper, "@isAdmin", DbType.Boolean, registration.isAdmin);
            var id = db.ExecuteScalar(dbCommandWrapper);
            registration.id = Convert.ToInt32(id);

            //return RedirectToRoute(new { controller = "login", action = "Index" });
            return Created(new Uri(Request.RequestUri + "/" + registration.id), registration);
        }
    }
}
