using FluentValidation;
using TaxiCompany.Application.Models.Impressions;

namespace TaxiCompany.Application.Models.Validators.Impressions;

public class UpdateImpressionsModelValidator : AbstractValidator<UpdateImpressionsModel>
{
    public UpdateImpressionsModelValidator()
    {
        RuleFor(cti => cti.Stars)
            .GreaterThanOrEqualTo(ImpressionsValidatorConfiguration.MinStarsValue)
            .WithMessage($"Minimum Value for Stars - {ImpressionsValidatorConfiguration.MinStarsValue}")
            .LessThanOrEqualTo(ImpressionsValidatorConfiguration.MaxStarsValue)
            .WithMessage($"Maximum Value for Stars - {ImpressionsValidatorConfiguration.MaxStarsValue}");
    }
}
