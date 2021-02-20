using LawyerWebSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.Entities.Concretes.DTOs
{
    public class AppUserUpdatePasswordDto : IDto
    {
        [Required(ErrorMessage = "E-posta adresinizi giriniz"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şu anki şifreinizi giriniz"), DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
        [Required(ErrorMessage = "Yeni şifre giriniz"), DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Compare("NewPassword", ErrorMessage = "Şifreler uyuşmuyor"), DataType(DataType.Password)]
        public string ReNewPassword { get; set; }
    }
}
