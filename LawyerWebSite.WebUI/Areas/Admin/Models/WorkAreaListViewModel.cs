using LawyerWebSite.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.WebUI.Areas.Admin.Models
{
    public class WorkAreaListViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public Category Category { get; set; }
    }
}
