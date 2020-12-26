using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.WebUI.Models
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage ="E-posta adresinizi giriniz"), DataType(DataType.EmailAddress, ErrorMessage ="Geçersiz e-posta")]
        public string Email { get; set; }
    }
}
