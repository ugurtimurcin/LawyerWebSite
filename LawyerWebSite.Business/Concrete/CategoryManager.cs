using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.Core.Utilities.Converter;
using LawyerWebSite.Core.Utilities.Results.Abstract;
using LawyerWebSite.Core.Utilities.Results.Concrete;
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

        public async Task<IResult> AddAsync(Category entity)
        {
            entity.Name = StringHelper.TitleToPascalCase(entity.Name);
            entity.Url = StringHelper.FriendlyUrl(entity.Name);
            await _categoryDal.AddAsync(entity);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Category entity)
        {
            await _categoryDal.DeleteAsync(entity);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<Category>>> GetAllAsync()
        {
            return new SuccessDataResult<List<Category>>(await _categoryDal.GetAllAsync());
        }

        public async Task<IDataResult<Category>> GetByIdAsync(int id)
        {
            return new SuccessDataResult<Category>(await _categoryDal.GetByIdAsync(id));
            throw new System.NotImplementedException();
        }

        public async Task<IDataResult<List<Category>>> GetCategoriesWithNotSelectedWorkAreaAsync()
        {
            return new SuccessDataResult<List<Category>>(await _categoryDal.GetCategoriesWithNotSelectedWorkAreaAsync());
        }

        public async Task<IDataResult<List<Category>>> GetCategoriesWithWorkAreaAsync()
        {
            return new SuccessDataResult<List<Category>>(await _categoryDal.GetCategoriesWithWorkAreaAsync());
        }

        public async Task<IDataResult<Category>> GetCategoryWithArticlesByIdAsync(int id)
        {
            return new SuccessDataResult<Category>(await _categoryDal.GetCategoryWithArticlesByIdAsync(id));
        }

        public async Task<IDataResult<Category>> GetCategoryWithArticlesByUrlAsync(string url)
        {
            return new SuccessDataResult<Category>(await _categoryDal.GetCategoryWithArticlesByUrlAsync(url));
        }

        public async Task<IResult> UpdateAsync(Category entity)
        {
            entity.Name = StringHelper.TitleToPascalCase(entity.Name);
            entity.Url = StringHelper.FriendlyUrl(entity.Name);
            await _categoryDal.UpdateAsync(entity);
            return new SuccessResult();
        }

       
    }
}
