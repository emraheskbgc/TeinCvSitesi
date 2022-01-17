using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeinCvSitesi.Models
{
    public class PersonalInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string NameSurname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public ICollection<Experience> Experiences { get; set; }
      
        public ProfileUpdate ProfileUpdate { get; set; }
    }
}