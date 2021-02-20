using LawyerWebSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawyerWebSite.Entities.Concretes.Entities
{
    public class WokrArea: IEntity
    {
        public int Id { get; set; }
        public string Desciption { get; set; }
        public string Picture { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
