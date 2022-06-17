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
        [Route("api/registrationPage")]
        [HttpPost]
        public IHttpActionResult CreateBook(registration registration)
        {
            //Sending user data to MSSQL database
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommandWrapper = db.GetStoredProcCommand("addUser");

            db.AddInParameter(dbCommandWrapper, "@Publisher", DbType.String, registration.name);
            db.AddInParameter(dbCommandWrapper, "@Writer", DbType.String, registration.email);
            db.AddInParameter(dbCommandWrapper, "@ISBN_Number", DbType.Int64, registration.phone);
            db.AddInParameter(dbCommandWrapper, "@Selling_Price", DbType.Int32, registration.fathersName);
            db.AddInParameter(dbCommandWrapper, "@Renting_Price", DbType.Int32, registration.gender);
            db.AddInParameter(dbCommandWrapper, "@Is_Rentable", DbType.Boolean, registration.governmentIdType);
            db.AddInParameter(dbCommandWrapper, "@Binding_Type", DbType.Int32, registration.governmentId);
            db.AddInParameter(dbCommandWrapper, "@Binding_Type", DbType.Int32, registration.dob);
            db.AddInParameter(dbCommandWrapper, "@Binding_Type", DbType.Int32, registration.address1);
            db.AddInParameter(dbCommandWrapper, "@Binding_Type", DbType.Int32, registration.address2);
            db.AddInParameter(dbCommandWrapper, "@Binding_Type", DbType.Int32, registration.city);
            db.AddInParameter(dbCommandWrapper, "@Binding_Type", DbType.Int32, registration.state);
            db.AddInParameter(dbCommandWrapper, "@Binding_Type", DbType.Int32, registration.pin);
            db.AddInParameter(dbCommandWrapper, "@Binding_Type", DbType.Int32, registration.password);
            db.AddInParameter(dbCommandWrapper, "@Binding_Type", DbType.Int32, registration.isAdmin);
            var id = db.ExecuteScalar(dbCommandWrapper);
            registration.id = Convert.ToInt32(id);

            return Created(new Uri(Request.RequestUri + "/" + registration.id), registration);
        }
    }
}
