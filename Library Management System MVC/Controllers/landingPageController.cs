﻿using Library_Management_System_MVC.Models;
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
    public class landingPageController : Controller
    {
        // GET: landingPage

        Uri baseAddress = new Uri(WebConfigurationManager.AppSettings["apibaseurl"]);
        HttpClient client;
        public landingPageController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        public ActionResult Index()
        {
            var model = new viewLandingPage();
            HttpResponseMessage reponse = client.GetAsync(client.BaseAddress + "/landingPage").Result;
            if (reponse.IsSuccessStatusCode)
            {
                string data = reponse.Content.ReadAsStringAsync().Result;
                model.Dict = JsonConvert.DeserializeObject<Dictionary<string, List<topBooks>>>(data);
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
    }
}