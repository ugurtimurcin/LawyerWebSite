using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.WebUI.Areas.Admin.Models
{
    public class AppUserRegisterModel
    {
        [Required(ErrorMessage ="İsim giriniz")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Soyisim giriniz")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Kullanıcı adı giriniz")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Şifre giriniz"), DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage ="Şifreler eşleşmiyor"), DataType(DataType.Password)]
        public string RePassword { get; set; }

        [Required(ErrorMessage ="E-Posta giriniz"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
