using FluentValidation;
using TaxiCompany.Application.Models.Company;
using TaxiCompany.Application.Models.Validators.CarsOwner;

namespace TaxiCompany.Application.Models.Validators.Company;

public class CreateCompanyModelValidator : AbstractValidator<CreateCompanyModel>
{
    public CreateCompanyModelValidator()
    {
        RuleFor(cti => cti.Comission)
            .GreaterThanOrEqualTo(CompanyValidatorConfiguration.MinComissionValue)
            .WithMessage($"Minimum Value for Comission - {CompanyValidatorConfiguration.MinComissionValue}")
            .LessThanOrEqualTo(CompanyValidatorConfiguration.MaxComissionValue)
            .WithMessage($"Maximum Value for Comission - {CompanyValidatorConfiguration.MaxComissionValue}");
    }
}
