using FluentValidation;
using LawyerWebSite.Entities.Concrete.DTOs;

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
