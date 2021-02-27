using LawyerWebSite.Core.Entities;
using LawyerWebSite.Entities.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.Entities.Concrete.DTOs
{
    public class CategoryAllListDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Article> Articles { get; set; }
    }
}
