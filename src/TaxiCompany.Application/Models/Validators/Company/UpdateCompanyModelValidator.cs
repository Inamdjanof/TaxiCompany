using FluentValidation;
using TaxiCompany.Application.Models.Company;

namespace TaxiCompany.Application.Models.Validators.Company;

public class UpdateCompanyModelValidator : AbstractValidator<UpdateCompanyModel>
{
    public UpdateCompanyModelValidator()
    {
        RuleFor(cti => cti.Comission)
            .GreaterThanOrEqualTo(CompanyValidatorConfiguration.MinComissionValue)
            .WithMessage($"Minimum Value for Comission - {CompanyValidatorConfiguration.MinComissionValue}")
            .LessThanOrEqualTo(CompanyValidatorConfiguration.MaxComissionValue)
            .WithMessage($"Maximum Value for Comission - {CompanyValidatorConfiguration.MaxComissionValue}");
    }
}
