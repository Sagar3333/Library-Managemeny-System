using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_Management_System_MVC.Models
{
    public class topBooks
    {
        public decimal rating { get; set; }
        public string bookTitle { get; set; }
        public int id { get; set; }
        public string genre { get; set; }
        public string publisher { get; set; }
        public string writers { get; set; }

    }
}