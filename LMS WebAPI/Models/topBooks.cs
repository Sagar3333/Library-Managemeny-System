using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS_WebAPI.Models
{
    public class topBooks
    {
        public decimal rating { get; set; }
        public string bookTitle { get; set; }
        public int rank { get; set; }
    }
}