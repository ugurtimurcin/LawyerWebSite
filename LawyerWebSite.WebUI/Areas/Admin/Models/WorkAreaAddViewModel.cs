using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.WebUI.Areas.Admin.Models
{
    public class WorkAreaAddViewModel
    {
        public string Description { get; set; }
        public string Picture { get; set; }
        public int CategoryId { get; set; }
    }
}
