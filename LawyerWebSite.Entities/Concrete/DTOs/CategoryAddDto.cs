﻿using LawyerWebSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.Entities.Concrete.DTOs
{
    public class CategoryAddDto : IDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Kategori adı girmelisiniz!")]
        public string Name { get; set; }
    }
}
