using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeinCvSitesi.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string SkillName { get; set; }
        public string Degree { get; set; }
      
        public virtual PersonalInfo PersonalInfo { get; set; }
        public int ProfilUpdateId { get; set; }
        public ProfileUpdate ProfileUpdate { get; set; }

    }
}