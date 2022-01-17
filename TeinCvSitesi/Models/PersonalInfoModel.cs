using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeinCvSitesi.Models
{
    public class PersonalInfoModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string NameSurname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}