using LawyerWebSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.Entities.Concrete.DTOs
{
    public class CategoryListDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
