using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.WebUI.Areas.Admin.Models
{
    public class ArticleAddViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Makale başlığı girmelisiniz")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Makale içeriği boş bırakılamaz")]
        public string Content { get; set; }
        //[Required(ErrorMessage ="Makale için bir kapak fotroğrafı yükleyin")]
        public string Picture { get; set; } = "default-article-cover.jpg";
        [Range(0, int.MaxValue), Required(ErrorMessage = "Lütfen kategori seçiniz")]
        public int CategoryId { get; set; }
    }
}
