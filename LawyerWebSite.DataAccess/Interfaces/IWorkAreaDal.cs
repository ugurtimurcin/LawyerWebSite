using LawyerWebSite.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawyerWebSite.DataAccess.Interfaces
{
    public interface IWorkAreaDal: IGenericDal<WokrArea>
    {
        List<WokrArea> GetWokrAreasWithCategory();
    }
}
