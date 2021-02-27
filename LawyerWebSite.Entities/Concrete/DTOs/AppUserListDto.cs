using LawyerWebSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.Entities.Concrete.DTOs
{
    public class AppUserListDto : IDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
