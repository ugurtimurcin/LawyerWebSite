using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.Core.Utilities.Results.Abstract;
using LawyerWebSite.Core.Utilities.Results.Concrete;
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
        public IDataResult<List<AppUser>> GetUsersNonAdmin()
        {
            return new SuccessDataResult<List<AppUser>>(_appUser.GetUsersNonAdmin());
        }
    }
}
