using FluentValidation;
using TaxiCompany.Application.Models.Person;
using TaxiCompany.Application.Models.Validators.Bank;

namespace TaxiCompany.Application.Models.Validators.Person;

public class CreatePersonModelValidator : AbstractValidator<CreatePersonModel>
{
    public CreatePersonModelValidator()
    {
        RuleFor(cti => cti.Name)
            .MaximumLength(PersonValidatorConfiguration.MaxNameLength)
            .WithMessage($"Maximum Length for Name - {PersonValidatorConfiguration.MaxNameLength}");
    }
}
