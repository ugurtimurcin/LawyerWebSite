using LawyerWebSite.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawyerWebSite.Entities.Concretes
{
    public class WokrArea: ITable
    {
        public int Id { get; set; }
        public string Desciption { get; set; }
        public string Picture { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
