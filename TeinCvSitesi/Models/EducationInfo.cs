using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeinCvSitesi.Models
{
    public class EducationInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string SchoolName { get; set; }
        public string Departman { get; set; }
        public string Year { get; set; }
        public virtual PersonalInfo PersonalInfo { get; set; }
        public ProfileUpdate ProfileUpdate { get; set; }
    }
}