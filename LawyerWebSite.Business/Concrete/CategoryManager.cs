using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.DataAccess.Interfaces;
using LawyerWebSite.Entities.Concrete.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LawyerWebSite.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public async Task AddAsync(Category entity)
        {
            await _categoryDal.AddAsync(entity);
        }

        public async Task DeleteAsync(Category entity)
        {
            await _categoryDal.DeleteAsync(entity);
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _categoryDal.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _categoryDal.GetByIdAsync(id);
        }

        public async Task<List<Category>> GetCategoriesWithNotSelectedWorkAreaAsync()
        {
            return await _categoryDal.GetCategoriesWithNotSelectedWorkAreaAsync();
        }

        public async Task<List<Category>> GetCategoriesWithWorkAreaAsync()
        {
            return await _categoryDal.GetCategoriesWithWorkAreaAsync();
        }

        public async Task<Category> GetCategoryWithArticlesByIdAsync(int id)
        {
            return await _categoryDal.GetCategoryWithArticlesByIdAsync(id);
        }

        public async Task<Category> GetCategoryWithArticlesByUrlAsync(string url)
        {
            return await _categoryDal.GetCategoryWithArticlesByUrlAsync(url);
        }

        public async Task UpdateAsync(Category entity)
        {
            await _categoryDal.UpdateAsync(entity);
        }
    }
}
