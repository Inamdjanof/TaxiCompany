using FluentValidation;
using TaxiCompany.Application.Models.Client;
using TaxiCompany.Application.Models.Validators.CarsOwner;

namespace TaxiCompany.Application.Models.Validators.Client;

public class UpdateClientModelValidator : AbstractValidator<UpdateClientModel>
{
    public UpdateClientModelValidator()
    {
        RuleFor(cti => cti.AccountWallet)
            .GreaterThanOrEqualTo(ClientValidatorConfiguration.MinAccountWalletValue)
            .WithMessage($"Minimum Value for Account Wallet - {ClientValidatorConfiguration.MinAccountWalletValue}");
    }
}
