using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Library_Management_System_MVC.Models;
using System.Web.Configuration;

namespace Library_Management_System_MVC.Controllers
{
    public class registrationController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //HttpClient client;
        //Uri baseAddress = new Uri(WebConfigurationManager.AppSettings["apibaseurl"]);
        //public registrationController()
        //{
        //    client = new HttpClient();
        //    client.BaseAddress = baseAddress;
        //}
        [HttpPost]
        public ActionResult Index(registration registration)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44340/api/registrationPage");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<registration>("registrationPage", registration);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    //return View(registration);
                    return RedirectToAction("Index", "login");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(registration);
        }
    }
}