
using LawyerWebSite.Core.Business;
using LawyerWebSite.Entities.Concrete;
using LawyerWebSite.Entities.Concrete.DTOs;
using LawyerWebSite.Entities.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LawyerWebSite.Business.Interfaces
{
    public interface IWorkAreaService: IGenericService<WorkArea>
    {
        Task<List<WorkAreaListDto>> GetWokrAreasWithCategoryAsync();
    }
}
