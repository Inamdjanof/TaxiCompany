using FluentValidation;
using TaxiCompany.Application.Models.Bank;

namespace TaxiCompany.Application.Models.Validators.Bank;

public class CreateBankModelValidator : AbstractValidator<CreateBankModel>
{
    public CreateBankModelValidator()
    {
        RuleFor(cti => cti.Name)
            .MaximumLength(BankValidatorConfiguration.MaxNameLength)
            .WithMessage($"Maximum Length for Name - {BankValidatorConfiguration.MaxNameLength}");
    }
}
