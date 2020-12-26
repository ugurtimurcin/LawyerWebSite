using LawyerWebSite.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawyerWebSite.Business.Interfaces
{
    public interface IAppUserService
    {
        List<AppUser> GetUsersNonAdmin();
    }
}
