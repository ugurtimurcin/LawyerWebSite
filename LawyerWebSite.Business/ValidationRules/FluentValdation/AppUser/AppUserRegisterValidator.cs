using FluentValidation;
using LawyerWebSite.Entities.Concrete.DTOs;

namespace LawyerWebSite.Business.ValidationRules.FluentValdation.AppUser
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.RePassword).NotEmpty();
        }
    }
}
