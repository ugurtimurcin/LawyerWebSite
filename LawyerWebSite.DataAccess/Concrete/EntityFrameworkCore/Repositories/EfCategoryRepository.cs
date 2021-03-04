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
    public class EfCategoryRepository : EfGenericRepository<Category, DataContext>, ICategoryDal
    {
        public async Task<List<Category>> GetCategoriesWithNotSelectedWorkAreaAsync()
        {
            using var context = new DataContext();
            return await context.Categories.Include(x => x.WorkArea).Where(x => x.WorkArea.Desciption == null).ToListAsync();
        }

        public async Task<List<Category>> GetCategoriesWithWorkAreaAsync()
        {
            using var context = new DataContext();
            return await context.Categories.Include(x => x.WorkArea).ToListAsync();
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
