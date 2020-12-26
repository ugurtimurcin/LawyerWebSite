using LawyerWebSite.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawyerWebSite.Business.Interfaces
{
    public interface IArticleService: IGenericService<Article>
    {
        Article GetArticleWithCategoryByUrl(string url);
        List<Article> GetArticlesTop6();
    }
}
