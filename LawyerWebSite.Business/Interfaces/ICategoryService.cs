using LawyerWebSite.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawyerWebSite.Business.Interfaces
{
    public interface ICategoryService: IGenericService<Category>
    {
        Category GetCategoryWithArticlesById(int id);
        Category GetCategoryWithArticlesByUrl(string url);
        List<Category> GetCategoriesWithWorkArea();
        List<Category> GetCategoriesWithNotSelectedWorkArea();

    }
}
