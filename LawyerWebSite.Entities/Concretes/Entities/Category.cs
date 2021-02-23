﻿using LawyerWebSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawyerWebSite.Entities.Concretes.Entities
{
    public class Category: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<Article> Articles { get; set; }
        public WokrArea WokrArea { get; set; }
    }
}