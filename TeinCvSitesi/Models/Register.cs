using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeinCvSitesi.Models
{
    public class Register
    {
        [Required]
        [DisplayName("Adınız")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Soyadınız")]
        public string SurName { get; set; }
        [Required]
        [DisplayName("E-Mail")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Kullanıcı Adınız")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Şifreniz")]
        public string Password { get; set; }
        [Required]
        [DisplayName("Şifrenizi Tekrar Giriniz")]
        [Compare("Password")]
        public string RePassword { get; set; }
    }
}