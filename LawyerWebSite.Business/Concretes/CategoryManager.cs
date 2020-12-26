using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.DataAccess.Interfaces;
using LawyerWebSite.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawyerWebSite.Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public void Create(Category entity)
        {
            _categoryDal.Create(entity);
        }

        public void Delete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public List<Category> GetCategoriesWithNotSelectedWorkArea()
        {
            return _categoryDal.GetCategoriesWithNotSelectedWorkArea();
        }

        public List<Category> GetCategoriesWithWorkArea()
        {
            return _categoryDal.GetCategoriesWithWorkArea();
        }

        public Category GetCategoryWithArticlesById(int id)
        {
            return _categoryDal.GetCategoryWithArticlesById(id);
        }

        public Category GetCategoryWithArticlesByUrl(string url)
        {
            return _categoryDal.GetCategoryWithArticlesByUrl(url);
        }

        public void Update(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
