using FluentValidation;
using TaxiCompany.Application.Models.Role;

namespace TaxiCompany.Application.Models.Validators.Role;

public class UpdateRoleModelValidator : AbstractValidator<UpdateRoleModel>
{
    public UpdateRoleModelValidator()
    {
        RuleFor(cti => cti.Name).MaximumLength(RoleValidatorConfiguration.MaxNameLength);

        RuleFor(cti => cti.Level).GreaterThanOrEqualTo(RoleValidatorConfiguration.MinLevelValue);

        RuleFor(cti => cti.Level).LessThanOrEqualTo(RoleValidatorConfiguration.MaxLevelValue);

        RuleFor(cti => cti.Salary).GreaterThanOrEqualTo(RoleValidatorConfiguration.MinSalaryValue);
    }
}
