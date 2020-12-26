using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.WebUI.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage ="Lütfen adınızı giriniz")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Lütfen soyadınızı giriniz")]
        public string SurName { get; set; }
        [Required(ErrorMessage ="Lütfen danışmak istediğiniz konuyu yazınız")]
        public string Topic { get; set; }
        [Required(ErrorMessage ="E-posta adresinizi giriniz."), DataType(DataType.EmailAddress, ErrorMessage ="E-posta adresinizi kontrol ediniz")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage ="Lütfen danışmak istediğiniz konuyu detaylı biçimde yazınız")]
        public string Content { get; set; }
    }
}
