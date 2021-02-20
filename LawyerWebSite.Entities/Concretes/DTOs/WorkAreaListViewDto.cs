using LawyerWebSite.Core.Entities;
using LawyerWebSite.Entities.Concretes;
using LawyerWebSite.Entities.Concretes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.Entities.Concretes.DTOs
{
    public class WorkAreaListViewDto : IDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public Category Category { get; set; }
    }
}
