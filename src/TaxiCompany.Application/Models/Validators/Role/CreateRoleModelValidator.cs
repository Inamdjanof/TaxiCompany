using FluentValidation;
using TaxiCompany.Application.Models.Role;
using TaxiCompany.Application.Models.Validators.Impressions;

namespace TaxiCompany.Application.Models.Validators.Role;

public class CreateRoleModelValidator : AbstractValidator<CreateRoleModel>
{
    public CreateRoleModelValidator()
    {
        RuleFor(cti => cti.Name)
            .MaximumLength(RoleValidatorConfiguration.MaxNameLength)
            .WithMessage($"Maximum Length for Name - {ImpressionsValidatorConfiguration.MinStarsValue}");

        RuleFor(cti => cti.Level)
            .GreaterThanOrEqualTo(RoleValidatorConfiguration.MinLevelValue)
            .WithMessage($"Minimum Value for Level - {RoleValidatorConfiguration.MinLevelValue}")
            .LessThanOrEqualTo(RoleValidatorConfiguration.MaxLevelValue)
            .WithMessage($"Maximum Value for Level - {RoleValidatorConfiguration.MaxLevelValue}");

        RuleFor(cti => cti.Salary)
            .GreaterThanOrEqualTo(RoleValidatorConfiguration.MinSalaryValue)
            .WithMessage($"Minimum Value for Salary - {RoleValidatorConfiguration.MinSalaryValue}");
    }
}
