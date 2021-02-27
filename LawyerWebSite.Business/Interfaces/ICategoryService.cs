using LawyerWebSite.Core.Business;
using LawyerWebSite.Entities.Concrete.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LawyerWebSite.Business.Interfaces
{
    public interface ICategoryService: IGenericService<Category>
    {
        Task<Category> GetCategoryWithArticlesByIdAsync(int id);
        Task<Category> GetCategoryWithArticlesByUrlAsync(string url);
        Task<List<Category>> GetCategoriesWithWorkAreaAsync();
        Task<List<Category>> GetCategoriesWithNotSelectedWorkAreaAsync();

    }
}
