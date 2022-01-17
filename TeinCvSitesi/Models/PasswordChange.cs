using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeinCvSitesi.Models
{
    public class PasswordChange
    {
        [Required]
        [DisplayName("Şimdiki Şifre")]
        public string OldPassword { get; set; }
        [Required]
        [DisplayName("Yeni Şifre")]
        public string NewPassword { get; set; }
        [Required]
        [DisplayName("Yeni Şifre Tekrar")]
        public string ConNewPassword { get; set; }

    }
}