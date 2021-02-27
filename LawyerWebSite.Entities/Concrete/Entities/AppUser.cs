using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawyerWebSite.Entities.Concrete.Entities
{
    public class AppUser: IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
