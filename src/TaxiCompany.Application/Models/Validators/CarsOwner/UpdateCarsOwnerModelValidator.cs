using FluentValidation;
using TaxiCompany.Application.Models.CarsOwner;

namespace TaxiCompany.Application.Models.Validators.CarsOwner;

public class UpdateCarsOwnerModelValidator : AbstractValidator<UpdateCarsOwnerModel>
{
    public UpdateCarsOwnerModelValidator()
    {
        RuleFor(cti => cti.Priority)
            .GreaterThanOrEqualTo(CarsOwnerValidatorConfiguration.MinPriorityValue)
            .WithMessage($"Minimum Value for Priority - {CarsOwnerValidatorConfiguration.MinPriorityValue}")
            .LessThanOrEqualTo(CarsOwnerValidatorConfiguration.MaxPriorityValue)
            .WithMessage($"Maximum Value for Priority - {CarsOwnerValidatorConfiguration.MinPriorityValue}");

        RuleFor(cti => cti.Rating)
            .GreaterThanOrEqualTo(CarsOwnerValidatorConfiguration.MinRatingValue)
            .WithMessage($"Minimum Value for Rating - {CarsOwnerValidatorConfiguration.MinRatingValue}")
            .LessThanOrEqualTo(CarsOwnerValidatorConfiguration.MaxRatingValue)
            .WithMessage($"Maximum Value for Rating - {CarsOwnerValidatorConfiguration.MaxRatingValue}");

        RuleFor(cti => cti.CompanyWallet)
            .GreaterThanOrEqualTo(CarsOwnerValidatorConfiguration.MinCompanyWalletValue)
            .WithMessage($"Minimum Value for Company Wallet - {CarsOwnerValidatorConfiguration.MaxRatingValue}");
    }
}
