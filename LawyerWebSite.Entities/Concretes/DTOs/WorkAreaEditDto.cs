using LawyerWebSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.Entities.Concretes.DTOs
{
    public class WorkAreaEditDto : IDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public int CategoryId { get; set; }
    }
}
