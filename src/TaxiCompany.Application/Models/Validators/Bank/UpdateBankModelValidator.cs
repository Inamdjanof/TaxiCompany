using FluentValidation;
using System.Diagnostics;
using TaxiCompany.Application.Models.Bank;

namespace TaxiCompany.Application.Models.Validators.Bank;

public class UpdateBankModelValidator : AbstractValidator<UpdateBankModel>
{
    public UpdateBankModelValidator()
    {
        RuleFor(cti => cti.Name)
            .MaximumLength(BankValidatorConfiguration.MaxNameLength)
            .WithMessage($"Maximum Length for Name - {BankValidatorConfiguration.MaxNameLength}");
    }
}
