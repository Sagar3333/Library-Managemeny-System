using Library_Management_System_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_Management_System_MVC.viewModel
{
    public class viewUserLandingPage
    {
        public Dictionary<string, List<topBooks>> topBooksDict { get; set; }
        public string email { get; set; }
    }
}