using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.DataAccess.Interfaces;
using LawyerWebSite.Entities.Concretes;
using LawyerWebSite.Entities.Concretes.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawyerWebSite.Business.Concretes
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
