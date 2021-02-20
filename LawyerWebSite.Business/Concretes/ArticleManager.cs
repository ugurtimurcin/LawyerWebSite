using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.DataAccess.Interfaces;
using LawyerWebSite.Entities.Concretes;
using LawyerWebSite.Entities.Concretes.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LawyerWebSite.Business.Concretes
{
    public class ArticleManager : IArticleService
    {
        private readonly IArticleDal _articleDal;
        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }
        public async Task AddAsync(Article entity)
        {
            await _articleDal.AddAsync(entity);
        }

        public async Task DeleteAsync(Article entity)
        {
            await _articleDal.DeleteAsync(entity);
        }

        public async Task<List<Article>> GetAllAsync()
        {
            return await _articleDal.GetAllAsync();
        }

        public async Task<List<Article>> GetArticlesTop6Async()
        {
            return await _articleDal.GetArticlesTop6Async();
        }

        public async Task<Article> GetArticleWithCategoryByUrlAsync(string url)
        {
            return await _articleDal.GetArticleWithCategoryByUrlAsync(url);
        }

        public async Task<Article> GetByIdAsync(int id)
        {
            return await _articleDal.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Article entity)
        {
            await _articleDal.UpdateAsync(entity);
        }
    }
}
