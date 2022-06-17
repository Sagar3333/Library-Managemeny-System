using Library_Management_System_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_Management_System_MVC.viewModel
{
    public class viewLandingPage
    {
        public Dictionary<string, List<topBooks>> Dict { get; set; }
    }
}