using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Management_System_MVC.Controllers
{
    public class adminController : Controller
    {
        // GET: admin
        public ActionResult Index(string email)
        {
            return View();
        }
    }
}