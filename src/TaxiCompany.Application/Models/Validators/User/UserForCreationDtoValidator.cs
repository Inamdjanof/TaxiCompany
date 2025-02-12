using FluentValidation;
using TaxiCompany.Application.Models.Users;

namespace TaxiCompany.Application.Validators.Users;

public class UserForCreationDtoValidator : AbstractValidator<UserForCreationDto>
{
    public UserForCreationDtoValidator()
    {
        RuleFor(user => user)
            .NotNull();

        RuleFor(user => user.firstName)
            .MaximumLength(100)
            .NotEmpty();

        RuleFor(user => user.email)
            .MaximumLength(100)
            .EmailAddress()
            .NotEmpty();
    }
}