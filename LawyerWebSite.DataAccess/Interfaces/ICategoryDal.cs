using LawyerWebSite.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawyerWebSite.DataAccess.Interfaces
{
    public interface ICategoryDal: IGenericDal<Category>
    {
        Category GetCategoryWithArticlesById(int id);
        Category GetCategoryWithArticlesByUrl(string url);
        List<Category> GetCategoriesWithWorkArea();
        List<Category> GetCategoriesWithNotSelectedWorkArea();
    }
}
