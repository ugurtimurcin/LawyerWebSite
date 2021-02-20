using LawyerWebSite.Entities.Concretes.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawyerWebSite.DataAccess.Interfaces
{
    public interface IAppUserDal
    {
        List<AppUser> GetUsersNonAdmin(); 
    }
}
