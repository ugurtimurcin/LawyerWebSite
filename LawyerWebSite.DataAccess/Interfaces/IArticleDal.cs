using LawyerWebSite.Core.DataAccess;
using LawyerWebSite.Entities.Concretes.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LawyerWebSite.DataAccess.Interfaces
{
    public interface IArticleDal: IGenericDal<Article>
    {
        Task<Article> GetArticleWithCategoryByUrlAsync(string url);
        Task<List<Article>> GetArticlesTop6Async();
    }
}
