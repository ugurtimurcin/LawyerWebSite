using LawyerWebSite.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawyerWebSite.DataAccess.Interfaces
{
    public interface IArticleDal: IGenericDal<Article>
    {
        Article GetArticleWithCategoryByUrl(string url);
        List<Article> GetArticlesTop6();
    }
}
