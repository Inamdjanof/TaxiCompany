using FluentValidation;
using TaxiCompany.Application.Models.Insurance;
using TaxiCompany.Application.Models.Validators.Impressions;

namespace TaxiCompany.Application.Models.Validators.Insurance;

public class CreateInsuranceModelValidator : AbstractValidator<CreateInsuranceModel>
{
    public CreateInsuranceModelValidator()
    {

        RuleFor(cti => cti.Num)
            .Length(InsuranceValidatorConfiguration.NumLength)
            .WithMessage($"Length for Num - {InsuranceValidatorConfiguration.NumLength}");

    }
}
