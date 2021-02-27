using LawyerWebSite.Entities.Concrete.Entities;
using System.Collections.Generic;

namespace LawyerWebSite.Business.Interfaces
{
    public interface IAppUserService
    {
        List<AppUser> GetUsersNonAdmin();
    }
}
