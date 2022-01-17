using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeinCvSitesi.Models
{
    public class Experience
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string WorkplaceName { get; set; }
        public string WorkYear { get; set; }
        public string Description { get; set; }
        public virtual PersonalInfo PersonalInfo { get; set; }
        public ProfileUpdate ProfileUpdate { get; set; }
    }
}