using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.Entities.Concrete.DTOs
{
    public class AppUserLoginDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "E-posta adresinizi giriniz"), DataType(DataType.EmailAddress, ErrorMessage = "Geçersiz e-posta adresi")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre giriniiz"), DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
