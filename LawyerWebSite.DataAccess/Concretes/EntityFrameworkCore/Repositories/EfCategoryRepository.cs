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
    public class EfCategoryRepository : EfGenericRepository<Category, DataContext>, ICategoryDal
    {
        public async Task<List<Category>> GetCategoriesWithNotSelectedWorkAreaAsync()
        {
            using var context = new DataContext();
            return await context.Categories.Include(x => x.WokrArea).Where(x => x.WokrArea.Desciption == null).ToListAsync();
        }

        public async Task<List<Category>> GetCategoriesWithWorkAreaAsync()
        {
            using var context = new DataContext();
            return await context.Categories.Include(x => x.WokrArea).ToListAsync();
        }

        public async Task<Category> GetCategoryWithArticlesByIdAsync(int id)
        {
            using var context = new DataContext();
            return await context.Categories.Include(a => a.Articles).Where(S => S.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Category> GetCategoryWithArticlesByUrlAsync(string url)
        {
            using var context = new DataContext();
            return await context.Categories.Include(a => a.Articles).Where(a => a.Url == url).FirstOrDefaultAsync();
        }
    }
}
