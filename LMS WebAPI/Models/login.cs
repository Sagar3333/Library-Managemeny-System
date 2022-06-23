using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS_WebAPI.Models
{
    public class login
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}