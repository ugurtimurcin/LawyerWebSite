using LawyerWebSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.Entities.Concretes.DTOs
{
    public class AppUserEditDto : IDto
    {
        [Required(ErrorMessage ="İsminizi giriniz")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyisminizi giriniz")]
        public string LastName { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "E-posta adresinizi giriniz"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
