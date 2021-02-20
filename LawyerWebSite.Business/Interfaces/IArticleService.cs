using LawyerWebSite.Core.Business;
using LawyerWebSite.Entities.Concretes.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LawyerWebSite.Business.Interfaces
{
    public interface IArticleService: IGenericService<Article>
    {
        Task<Article> GetArticleWithCategoryByUrlAsync(string url);
        Task<List<Article>> GetArticlesTop6Async();
    }
}
