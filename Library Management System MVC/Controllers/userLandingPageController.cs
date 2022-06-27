using Library_Management_System_MVC.Models;
using Library_Management_System_MVC.viewModel;
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
    public class userLandingPageController : Controller
    {
        Uri baseAddress = new Uri(WebConfigurationManager.AppSettings["apibaseurl"]);
        HttpClient client;
        public userLandingPageController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        public ActionResult Index(string email)
        {
            var model = new viewUserLandingPage();
            model.email = email;
            HttpResponseMessage reponse = client.GetAsync(client.BaseAddress + "/landingPage").Result;
            if (reponse.IsSuccessStatusCode)
            {
                string data = reponse.Content.ReadAsStringAsync().Result;
                model.topBooksDict = JsonConvert.DeserializeObject<Dictionary<string, List<topBooks>>>(data);
            }
            return View(model);
        }
        public ActionResult aboutBook(int id)
        {
            var model = new topBooks();
            HttpResponseMessage reponse = client.GetAsync(client.BaseAddress + "/aboutBook/" + id).Result;
            if (reponse.IsSuccessStatusCode)
            {
                string data = reponse.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<topBooks>(data);
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult addToCart(int id, string email)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WebConfigurationManager.AppSettings["apibaseurl"]);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<string>("addToCart/"+id+"?email="+email, null);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "userLandingPage");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View();
        }

        //public ActionResult addToCart(int id, string email)
        //{
        //    string  id2 = email;
        //    var model = new viewLandingPage();
        //    HttpResponseMessage reponse = client.GetAsync(client.BaseAddress + "/addToCart/" + id + "/" + id2).Result;
        //    if (reponse.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index", "userLandingPage");
        //    }
        //    return RedirectToAction("Index", "userLandingPage");

        //}
    }

}