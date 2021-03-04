using System.Collections.Generic;
using System.Threading.Tasks;
using LawyerWebSite.Core.Utilities.Results.Abstract;
using LawyerWebSite.Entities.Concrete.DTOs;
using LawyerWebSite.Entities.Concrete.Entities;
using Microsoft.AspNetCore.Http;

namespace LawyerWebSite.Business.Interface
{
    public interface IWorkAreaService
    {
        Task<IResult> AddAsync(WorkArea entity, IFormFile file);
        Task<IResult> UpdateAsync(WorkArea entity, IFormFile file);
        Task<IResult> DeleteAsync(WorkArea entity);
        Task<IDataResult<WorkArea>> GetByIdAsync(int id);
        Task<IDataResult<List<WorkArea>>> GetAllAsync();
        Task<IDataResult<List<WorkAreaListDto>>> GetWokrAreasWithCategoryAsync();
    }
}
