using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Library_Management_System_MVC.Models;

namespace Library_Management_System_MVC.Controllers
{
    public class registrationController : Controller
    {
        public ActionResult Index()
        {
            //var registration = new registration();
            //registration.genders = new List<SelectListItem>
            //{
            //    new SelectListItem
            //    {
            //        Text = "Female", Value = "0"
            //    },
            //    new SelectListItem
            //    {
            //        Text = "Male", Value = "1"
            //    }
            //};
            //registration.governmentIdTypes = new List<SelectListItem>
            //{
            //    new SelectListItem
            //    {
            //        Text = "Aadhar card", Value = "1"
            //    },
            //    new SelectListItem
            //    {
            //        Text = "Driving License", Value = "2"
            //    },
            //    new SelectListItem
            //    {
            //        Text = "Voter ID card", Value = "3"
            //    }
            //};
            //registration.isAdmins = new List<SelectListItem>
            //{
            //    new SelectListItem
            //    {
            //        Text = "User", Value = "0"
            //    },
            //    new SelectListItem
            //    {
            //        Text = "Admin", Value = "1"
            //    }

            //};
            //return View(registration);
            return View();
        }

        //[HttpPost]
        //public ActionResult Index(registration registration)
        //{
        //    var department = Index() { DepartmentName = "Test Department" };
        //    HttpResponseMessage response = awaitclient.PostAsJsonAsync("api/registrationPage", department);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        // Get the URI of the created resource.
        //        UrireturnUrl = response.Headers.Location;
        //        Console.WriteLine(returnUrl);
        //    }
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