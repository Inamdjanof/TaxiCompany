using FluentValidation;
using TaxiCompany.Application.Models.Impressions;
using TaxiCompany.Application.Models.Validators.Document;

namespace TaxiCompany.Application.Models.Validators.Impressions;

public class CreateImpressionsModelValidator : AbstractValidator<CreateImpressionsModel>
{
    public CreateImpressionsModelValidator()
    {
        RuleFor(cti => cti.Stars)
            .GreaterThanOrEqualTo(ImpressionsValidatorConfiguration.MinStarsValue)
            .WithMessage($"Minimum Value for Stars - {ImpressionsValidatorConfiguration.MinStarsValue}")
            .LessThanOrEqualTo(ImpressionsValidatorConfiguration.MaxStarsValue)
            .WithMessage($"Maximum Value for Stars - {ImpressionsValidatorConfiguration.MaxStarsValue}");
    }
}
