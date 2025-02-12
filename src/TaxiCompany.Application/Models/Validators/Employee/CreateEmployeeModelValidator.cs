using FluentValidation;
using FluentValidation.Validators;
using TaxiCompany.Application.Models.Employee;
using TaxiCompany.Application.Models.Validators.Document;

namespace TaxiCompany.Application.Models.Validators.Employee;

public class CreateEmployeeModelValidator : AbstractValidator<CreateEmployeeModel>
{
    public CreateEmployeeModelValidator()
    {
        RuleFor(cti => cti.Name)
            .MaximumLength(EmployeeValidatorConfiguration.MaxNameLength)
            .WithMessage($"Maximum for Name - {EmployeeValidatorConfiguration.MaxNameLength}");
    }
}
