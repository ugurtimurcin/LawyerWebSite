using LawyerWebSite.Core.DataAccess;
using LawyerWebSite.DataAccess.Concrete.EntityFrameworkCore.Context;
using LawyerWebSite.Entities.Concrete.DTOs;
using LawyerWebSite.Entities.Concrete.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LawyerWebSite.DataAccess.Interface;

namespace LawyerWebSite.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfWorkAreaRepository : EfGenericRepository<WorkArea, DataContext>, IWorkAreaDal
    {
        public async Task<List<WorkAreaListDto>> GetWokrAreasWithCategoryAsync()
        {
            using var context = new DataContext();

            var result = from w in context.WokrAreas
                         join c in context.Categories
                         on w.CategoryId equals c.Id
                         select new WorkAreaListDto
                         {
                             Id = w.Id,
                             CategoryName = c.Name,
                             Description = w.Desciption,
                             Picture = w.Picture
                         };
            return await result.ToListAsync();
        }
    }
}
