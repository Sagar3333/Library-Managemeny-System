using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Library_Management_System_MVC.Models;
using System.Net.Http.Formatting.Extension;

namespace Library_Management_System_MVC.Controllers
{
    public class registrationController : Controller
    {
        // GET: registration
        public ActionResult Index()
        {
            //consume Web API Get method here.. 

            return View();
        }

        [HttpPost]
        public ActionResult Index(registration registration)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64189/api/student");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<registration>("", registration);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(student);
        }
    }
}