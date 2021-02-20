using LawyerWebSite.Core.DataAccess;
using LawyerWebSite.DataAccess.Concretes.EntityFrameworkCore.Context;
using LawyerWebSite.Entities.Concretes.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LawyerWebSite.DataAccess.Interfaces
{
    public interface IWorkAreaDal: IGenericDal<WokrArea>
    {
        Task<List<WokrArea>> GetWokrAreasWithCategoryAsync();
    }
}
