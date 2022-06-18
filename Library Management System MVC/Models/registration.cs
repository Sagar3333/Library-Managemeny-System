using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Management_System_MVC.Models
{
    public class registration
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string fathersName { get; set; }
        public Boolean gender { get; set; }
        public IEnumerable<SelectListItem> genders { get; set; }
        public int governmentIdType { get; set; }
        public IEnumerable<SelectListItem> governmentIdTypes { get; set; }
        public string governmentId { get; set; }
        [DisplayName("Date of Birth:")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime dob { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string pin { get; set; }
        [DisplayName("Password:")]
        public Byte password { get; set; }
        public Byte confirmPwd { get; set; }
        public Boolean isAdmin { get; set; }
        public IEnumerable<SelectListItem> isAdmins { get; set; }
    }
}