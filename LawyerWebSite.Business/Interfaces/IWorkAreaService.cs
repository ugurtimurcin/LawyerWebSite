﻿
using LawyerWebSite.Core.Business;
using LawyerWebSite.Entities.Concretes;
using LawyerWebSite.Entities.Concretes.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LawyerWebSite.Business.Interfaces
{
    public interface IWorkAreaService: IGenericService<WokrArea>
    {
        Task<List<WokrArea>> GetWokrAreasWithCategoryAsync();
    }
}
