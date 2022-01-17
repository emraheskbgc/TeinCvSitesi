using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeinCvSitesi.Models
{
    public class ProfileUpdate
    {
        public string Id { get; set; }
        [Required]
        [DisplayName("Adı")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Soyadı")]
        public string SurName { get; set; }
        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("E-Mail")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Telefon")]
        public string PhoneNumber { get; set; }
        [Required]
        [DisplayName("Beceriler")]
        public ICollection<Skill> Skills { get; set; }

    }
}