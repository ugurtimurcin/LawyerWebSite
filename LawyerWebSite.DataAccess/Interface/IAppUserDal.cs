using LawyerWebSite.Entities.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawyerWebSite.DataAccess.Interface
{
    public interface IAppUserDal
    {
        List<AppUser> GetUsersNonAdmin(); 
    }
}
