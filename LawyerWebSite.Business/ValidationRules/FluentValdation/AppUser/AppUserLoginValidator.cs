using FluentValidation;
using LawyerWebSite.Entities.Concretes.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawyerWebSite.Business.ValidationRules.FluentValdation.AppUser
{
    public class AppUserLoginValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
