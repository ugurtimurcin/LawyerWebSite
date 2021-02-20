using LawyerWebSite.Core.DataAccess;
using LawyerWebSite.DataAccess.Concretes.EntityFrameworkCore.Context;
using LawyerWebSite.DataAccess.Interfaces;
using LawyerWebSite.Entities.Concretes.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.DataAccess.Concretes.EntityFrameworkCore.Repositories
{
    public class EfArticleRepository : EfGenericRepository<Article, DataContext>, IArticleDal
    {
        public async Task<List<Article>> GetArticlesTop6Async()
        {
            using var context = new DataContext();
            return await context.Articles.OrderByDescending(x => x.DateTime).Take(6).ToListAsync();
        }

        public async Task<Article> GetArticleWithCategoryByUrlAsync(string url)
        {
            using var context = new DataContext();
            return await context.Articles.Include(a => a.Category).Where(a => a.Url == url).FirstOrDefaultAsync();
        }
    }
}
