using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.Entities.Concretes.DTOs
{
    public class WorkAreaAddDto
    {
        public string Description { get; set; }
        public string Picture { get; set; }
        public int CategoryId { get; set; }
    }
}
