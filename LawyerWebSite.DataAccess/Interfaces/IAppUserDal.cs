using LawyerWebSite.Entities.Concretes;
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
