using FluentValidation;
using TaxiCompany.Application.Models.CarsOwner;
using TaxiCompany.Application.Models.Validators.Card;

namespace TaxiCompany.Application.Models.Validators.CarsOwner;

public class CreateCarsOwnerModelValidator : AbstractValidator<CreateCarsOwnerModel>
{
    public CreateCarsOwnerModelValidator()
    {
        RuleFor(cti => cti.CompanyWallet)
            .GreaterThanOrEqualTo(CarsOwnerValidatorConfiguration.MinCompanyWalletValue)
            .WithMessage($"Minimum Value for Company Wallet - {CarsOwnerValidatorConfiguration.MinCompanyWalletValue}");
    }
}
