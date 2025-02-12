using FluentValidation;
using TaxiCompany.Application.Models.Card;
using TaxiCompany.Application.Models.Validators.Bank;

namespace TaxiCompany.Application.Models.Validators.Card;

public class CreateCardModelValidator : AbstractValidator<CreateCardModel>
{
    public CreateCardModelValidator()
    {
        RuleFor(cti => cti.Term)
            .Length(CardValidatorConfiguration.TermLength)
            .WithMessage($"Length for Term - {CardValidatorConfiguration.TermLength}");

        RuleFor(cti => cti.Num)
            .Length(CardValidatorConfiguration.NumLength)
            .WithMessage($"Length for Num - {CardValidatorConfiguration.NumLength}");

        RuleFor(cti => cti.Balance)
            .GreaterThanOrEqualTo(CardValidatorConfiguration.MinBalanceValue)
            .WithMessage($"Minimum Value for Balance - {CardValidatorConfiguration.MinBalanceValue}");
    }
}
