using Library_Management_System_MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Library_Management_System_MVC.Controllers
{
    public class loginController : Controller
    {
        // GET: login
        Uri baseAddress = new Uri("https://localhost:44340/api");
        HttpClient client;
        public loginController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var model = new login();
            string loginStatus = "you are not registered";
            HttpResponseMessage reponse = client.GetAsync(client.BaseAddress + "/AuthenticateUser").Result;
            if (reponse.IsSuccessStatusCode)
            {
                string data = reponse.Content.ReadAsStringAsync().Result;
                loginStatus = JsonConvert.DeserializeObject<string>(data);
            }
            if (loginStatus == "")
            {
                model.loginStatus = loginStatus;
            }
            else if (loginStatus == "password is incorrect")
            {
                model.loginStatus = loginStatus;
            }
            else if (loginStatus == "login successfull")
            {
                return RedirectToAction("Index", "user");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(login login)
        {
            return RedirectToAction("Index", login);
        }

        //[HttpPost]
        //public ActionResult Index(login login)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:44340/api/login");

        //        //HTTP POST
        //        var postTask = client.PostAsJsonAsync<login>("login", login);
        //        postTask.Wait();

        //        var result = postTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            return Redirect(
        //                Url.RouteUrl("DefaultApi",
        //        new
        //        {
        //            httproute = "",
        //            controller = "login",
        //            action = "AuthenticateUser",
        //            id = login.email,
        //            id2 = login.password
        //        }));
        //        }
        //    }

        //    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

        //    return View(login);
        //}
    }
}