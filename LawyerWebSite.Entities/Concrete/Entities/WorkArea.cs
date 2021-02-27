using LawyerWebSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawyerWebSite.Entities.Concrete.Entities
{
    public class WorkArea: IEntity
    {
        public int Id { get; set; }
        public string Desciption { get; set; }
        public string Picture { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
