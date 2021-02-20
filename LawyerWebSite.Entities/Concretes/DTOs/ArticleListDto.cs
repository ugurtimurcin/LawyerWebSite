using LawyerWebSite.Core.Entities;
using LawyerWebSite.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.Entities.Concretes.DTOs
{
    public class ArticleListDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Picture { get; set; }
        public string Url { get; set; }
        public DateTime DateTime { get; set; }
    }
}
