using System.Collections.Generic;
using System.Threading.Tasks;
using LawyerWebSite.Core.DataAccess;
using LawyerWebSite.Entities.Concrete.Entities;

namespace LawyerWebSite.DataAccess.Interface
{
    public interface ICategoryDal: IGenericDal<Category>
    {
        Task<Category> GetCategoryWithArticlesByIdAsync(int id);
        Task<Category> GetCategoryWithArticlesByUrlAsync(string url);
        Task<List<Category>> GetCategoriesWithWorkAreaAsync();
        Task<List<Category>> GetCategoriesWithNotSelectedWorkAreaAsync();
    }
}
