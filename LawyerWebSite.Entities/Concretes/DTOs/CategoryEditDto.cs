using LawyerWebSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.Entities.Concretes.DTOs
{
    public class CategoryEditDto : IDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Kategori Adı giriniz")]
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
