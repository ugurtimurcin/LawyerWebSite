using FluentValidation;
using LawyerWebSite.Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawyerWebSite.Business.ValidationRules.FluentValdation.AppUser
{
    public class AppUserEditValidator : AbstractValidator<AppUserEditDto>
    {
        public AppUserEditValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
}
