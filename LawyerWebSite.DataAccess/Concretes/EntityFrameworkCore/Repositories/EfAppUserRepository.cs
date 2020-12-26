using LawyerWebSite.DataAccess.Concretes.EntityFrameworkCore.Context;
using LawyerWebSite.DataAccess.Interfaces;
using LawyerWebSite.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LawyerWebSite.DataAccess.Concretes.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : IAppUserDal
    {
        public List<AppUser> GetUsersNonAdmin()
        {
            using var context = new DataContext();
            return context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId,
                (resultUser, resultUserRole) => new
                {
                    user = resultUser,
                    userRole = resultUserRole

                }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id, (resultTable, resultRole) => new
                {
                    user = resultTable.user,
                    userRoles = resultTable.userRole,
                    roles = resultRole
                }).Where(a => a.roles.Name == "Member").Select(s => new AppUser
                {
                    Id = s.user.Id,
                    UserName = s.user.UserName,
                    FirstName = s.user.FirstName,
                    LastName = s.user.LastName,
                    Email = s.user.Email,
                    EmailConfirmed = s.user.EmailConfirmed
                }).ToList();
        }

    }
}