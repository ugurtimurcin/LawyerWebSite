﻿using LawyerWebSite.Core.Utilities.Results.Abstract;
using LawyerWebSite.Entities.Concrete.Entities;
using System.Collections.Generic;

namespace LawyerWebSite.Business.Interface
{
    public interface IAppUserService
    {
        IDataResult<List<AppUser>> GetUsersNonAdmin();
    }
}
