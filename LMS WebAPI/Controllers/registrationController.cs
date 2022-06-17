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
            DbCommand dbCommandWrapper = db.GetStoredProcCommand("AddBookData");
            //db.AddInParameter(dbCommandWrapper, "@Id", DbType.Int32, bookModel.id);

            //db.AddInParameter(dbCommandWrapper, "@Title", DbType.String, registration.title);
            //db.AddInParameter(dbCommandWrapper, "@Publisher", DbType.String, registration.publisher);
            //db.AddInParameter(dbCommandWrapper, "@Writer", DbType.String, registration.writer);
            //db.AddInParameter(dbCommandWrapper, "@ISBN_Number", DbType.Int64, registration.ISBN_number);
            //db.AddInParameter(dbCommandWrapper, "@Selling_Price", DbType.Int32, registration.selling_price);
            //db.AddInParameter(dbCommandWrapper, "@Renting_Price", DbType.Int32, registration.renting_price);
            //db.AddInParameter(dbCommandWrapper, "@Is_Rentable", DbType.Boolean, registration.is_rentable);
            //db.AddInParameter(dbCommandWrapper, "@Binding_Type", DbType.Int32, registration.binding_type);
            //var id = db.ExecuteScalar(dbCommandWrapper);
            //registration.id = Convert.ToInt32(id);

            return Created(new Uri(Request.RequestUri + "/" + registration.id), registration);
        }
    }
}
