using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS_WebAPI.Models
{
    public class registration
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string fathersName { get; set; }
        public Boolean gender { get; set; }
        public int governmentIdType { get; set; }
        public string governmentId { get; set; }
        public DateTime dob { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string pin { get; set; }
        public Byte password { get; set; }
        public Boolean isAdmin { get; set; }
    }
}