using LawyerWebSite.Core.DataAccess;
using LawyerWebSite.DataAccess.Concrete.EntityFrameworkCore.Context;
using LawyerWebSite.Entities.Concrete.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LawyerWebSite.DataAccess.Interface;

namespace LawyerWebSite.DataAccess.Concrete.EntityFrameworkCore.Repositories
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
