using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.WebUI.Models
{
    public class ResetPasswordViewModel
    {
        public string Token { get; set; }
        [Required(ErrorMessage ="E-posta adresinizi giriniz"), DataType(DataType.EmailAddress, ErrorMessage ="Geçersiz e-posta adresi")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Şifre girinizi"), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
