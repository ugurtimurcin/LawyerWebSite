using LawyerWebSite.Core.DataAccess;
using LawyerWebSite.DataAccess.Concretes.EntityFrameworkCore.Context;
using LawyerWebSite.DataAccess.Interfaces;
using LawyerWebSite.Entities.Concretes.DTOs;
using LawyerWebSite.Entities.Concretes.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.DataAccess.Concretes.EntityFrameworkCore.Repositories
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
