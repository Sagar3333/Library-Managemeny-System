using LMS_WebAPI.Models;
using System;
using System.Collections.Generic;
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
        public IHttpActionResult LoginUser(login login)
        {
            return Redirect(
            Url.Route("DefaultApi",
                new
                {
                    httproute = "",
                    controller = "LoginPageController",
                    action = "AuthenticateUser",
                    id = login.email,
                    id2 = login.password
                }));
        }
        //[HttpGet]
        //public HttpResponseMessage AuthenticateUser([FromUri] string id, [FromUri] byte id2)
        //{

        //}
    }
}
