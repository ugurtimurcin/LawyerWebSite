using LawyerWebSite.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawyerWebSite.Entities.Concretes
{
    public class Article: ITable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Content { get; set; }
        public string Picture { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
