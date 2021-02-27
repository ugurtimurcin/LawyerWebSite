using LawyerWebSite.Core.Entities;
using System;

namespace LawyerWebSite.Entities.Concrete.DTOs
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
