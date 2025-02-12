using FluentValidation;
using TaxiCompany.Application.Models.Person;

namespace TaxiCompany.Application.Models.Validators.Person;

public class UpdatePersonModelValidator : AbstractValidator<UpdatePersonModel>
{
    public UpdatePersonModelValidator()
    {
        RuleFor(cti => cti.Name)
            .MaximumLength(PersonValidatorConfiguration.MaxNameLength)
            .WithMessage($"Maximum Length for Name - {PersonValidatorConfiguration.MaxNameLength}");
    }

}
