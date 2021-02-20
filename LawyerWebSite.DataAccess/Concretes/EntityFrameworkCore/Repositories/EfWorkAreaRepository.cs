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
    public class EfWorkAreaRepository : EfGenericRepository<WokrArea, DataContext>, IWorkAreaDal
    {
        public async Task<List<WokrArea>> GetWokrAreasWithCategoryAsync()
        {
            using var context = new DataContext();
            return await context.WokrAreas.Include(x => x.Category).ToListAsync();
        }
    }
}
