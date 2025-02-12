using FluentValidation;
using TaxiCompany.Application.Models.Users;

namespace TaxiCompany.Application.Validators.Users;

public class UserForModificationDtoValidator : AbstractValidator<UserForModificationDto>
{
    public UserForModificationDtoValidator()
    {
        RuleFor(user => user)
            .NotNull();

        RuleFor(user => user.userId)
            .NotEqual(default(Guid));
    }
}