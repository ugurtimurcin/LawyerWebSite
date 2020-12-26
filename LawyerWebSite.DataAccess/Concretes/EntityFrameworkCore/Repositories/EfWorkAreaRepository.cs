using LawyerWebSite.DataAccess.Concretes.EntityFrameworkCore.Context;
using LawyerWebSite.DataAccess.Interfaces;
using LawyerWebSite.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LawyerWebSite.DataAccess.Concretes.EntityFrameworkCore.Repositories
{
    public class EfWorkAreaRepository : EfGenericRepository<WokrArea, DataContext>, IWorkAreaDal
    {
        public List<WokrArea> GetWokrAreasWithCategory()
        {
            using var context = new DataContext();
            return context.WokrAreas.Include(x => x.Category).ToList();
        }
    }
}
