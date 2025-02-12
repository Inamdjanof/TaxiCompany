using FluentValidation;
using TaxiCompany.Application.Models.Card;
using TaxiCompany.Application.Models.Validators.CarsOwner;

namespace TaxiCompany.Application.Models.Validators.Card;

public class UpdateCardModelValidator : AbstractValidator<UpdateCardModel>
{
    public UpdateCardModelValidator()
    {

        RuleFor(cti => cti.Balance)
            .GreaterThanOrEqualTo(CardValidatorConfiguration.MinBalanceValue)
            .WithMessage($"Minimum Value for Balance - {CardValidatorConfiguration.MinBalanceValue}");
    }
}
