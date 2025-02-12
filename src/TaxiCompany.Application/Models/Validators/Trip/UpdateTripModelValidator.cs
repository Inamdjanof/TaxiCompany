using FluentValidation;
using TaxiCompany.Application.Models.Trip;

namespace TaxiCompany.Application.Models.Validators.Trip;

public class UpdateTripModelValidator : AbstractValidator<UpdateTripModel>
{
    public UpdateTripModelValidator()
    {
        RuleFor(cti => cti.Cost)
            .GreaterThanOrEqualTo(TripValidatorConfiguration.MinCostValue)
            .WithMessage($"Minimum Value for Cost - {TripValidatorConfiguration.MinCostValue}");
    }
}
