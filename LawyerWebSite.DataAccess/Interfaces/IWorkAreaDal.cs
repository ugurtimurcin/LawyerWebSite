using LawyerWebSite.Core.DataAccess;
using LawyerWebSite.DataAccess.Concrete.EntityFrameworkCore.Context;
using LawyerWebSite.Entities.Concrete.DTOs;
using LawyerWebSite.Entities.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LawyerWebSite.DataAccess.Interfaces
{
    public interface IWorkAreaDal: IGenericDal<WorkArea>
    {
        Task<List<WorkAreaListDto>> GetWokrAreasWithCategoryAsync();
    }
}
