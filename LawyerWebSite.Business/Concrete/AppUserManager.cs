using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.DataAccess.Interfaces;
using LawyerWebSite.Entities.Concrete.Entities;
using System.Collections.Generic;

namespace LawyerWebSite.Business.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUser;
        public AppUserManager(IAppUserDal appUser)
        {
            _appUser = appUser;
        }
        public List<AppUser> GetUsersNonAdmin()
        {
            return _appUser.GetUsersNonAdmin();
        }
    }
}
