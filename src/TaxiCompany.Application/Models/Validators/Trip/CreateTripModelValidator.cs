using FluentValidation;
using TaxiCompany.Application.Models.Trip;
using TaxiCompany.Application.Models.Validators.Document;

namespace TaxiCompany.Application.Models.Validators.Trip;

public class CreateTripModelValidator : AbstractValidator<CreateTripModel>
{
    public CreateTripModelValidator()
    {
        RuleFor(cti => cti.Cost)
            .GreaterThanOrEqualTo(TripValidatorConfiguration.MinCostValue)
            .WithMessage($"Minimum Value for Cost - {TripValidatorConfiguration.MinCostValue}");
    }
}
