using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.WebUI.Areas.Admin.Models
{
    public class CategoryAddViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Kategori adı girmelisiniz!")]
        public string Name { get; set; }
    }
}
