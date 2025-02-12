using FluentValidation;
using TaxiCompany.Application.Models.Bank;
using TaxiCompany.Application.Models.Car;
using TaxiCompany.Application.Models.Validators.Bank;

namespace TaxiCompany.Application.Models.Validators.Car;

public class CreateCarModelValidator : AbstractValidator<CreateCarModel>
{
    public CreateCarModelValidator()
    {
        RuleFor(cti => cti.Model)
            .MaximumLength(CarValidatorConfiguration.MaxModelLength)
            .WithMessage($"Maximum Length for Model - {CarValidatorConfiguration.MaxModelLength}");
    }
}
