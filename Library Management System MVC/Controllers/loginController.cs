using Library_Management_System_MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Library_Management_System_MVC.Controllers
{
    public class loginController : Controller
    {
        // GET: login
        HttpClient client;
        Uri baseAddress = new Uri(WebConfigurationManager.AppSettings["apibaseurl"]);
        public loginController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var model = new login();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(login login, string email)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44340/api/login");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<login>("login", login);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    var loginStatus = JsonConvert.DeserializeObject<string>(data);

                    if (loginStatus == "you are not registered" || loginStatus == "password is incorrect")
                    {
                        login.loginStatus = loginStatus;
                        return View(login);
                    }
                    else if (loginStatus == "True")
                    {
                        return RedirectToAction("Index", "admin", email);
                    }
                    else if (loginStatus == "False")
                    {
                        return RedirectToAction("Index", "user", email);
                    }
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(login);
        }
    }
}