using LawyerWebSite.Core.Utilities.Results.Abstract;
using LawyerWebSite.Entities.Concrete.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LawyerWebSite.Business.Interfaces
{
    public interface ICategoryService
    {
        Task<IResult> AddAsync(Category entity);
        Task<IResult> UpdateAsync(Category entity);
        Task<IResult> DeleteAsync(Category entity);
        Task<IDataResult<Category>> GetByIdAsync(int id);
        Task<IDataResult<List<Category>>> GetAllAsync();
        Task<IDataResult<Category>> GetCategoryWithArticlesByIdAsync(int id);
        Task<IDataResult<Category>> GetCategoryWithArticlesByUrlAsync(string url);
        Task<IDataResult<List<Category>>> GetCategoriesWithWorkAreaAsync();
        Task<IDataResult<List<Category>>> GetCategoriesWithNotSelectedWorkAreaAsync();

    }
}
