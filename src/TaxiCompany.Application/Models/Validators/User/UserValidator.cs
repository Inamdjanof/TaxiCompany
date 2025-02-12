using FluentValidation;
using TaxiCompany.Core.Entities;

namespace TaxiCompany.Application.Validators.Users;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user)
            .NotEmpty();
    }
}