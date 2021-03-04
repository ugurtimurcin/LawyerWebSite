using System.Collections.Generic;
using System.Threading.Tasks;
using LawyerWebSite.Core.DataAccess;
using LawyerWebSite.Entities.Concrete.DTOs;
using LawyerWebSite.Entities.Concrete.Entities;

namespace LawyerWebSite.DataAccess.Interface
{
    public interface IWorkAreaDal: IGenericDal<WorkArea>
    {
        Task<List<WorkAreaListDto>> GetWokrAreasWithCategoryAsync();
    }
}
