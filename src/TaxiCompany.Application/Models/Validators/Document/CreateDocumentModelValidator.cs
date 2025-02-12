using FluentValidation;
using TaxiCompany.Application.Models.Document;
using TaxiCompany.Application.Models.Validators.Company;

namespace TaxiCompany.Application.Models.Validators.Document;

public class CreateDocumentModelValidator : AbstractValidator<CreateDocumentModel>
{
    public CreateDocumentModelValidator()
    {
        RuleFor(cti => cti.Series)
            .Length(DocumentValidatorConfiguration.SeriesLength)
            .WithMessage($"Length for Series - {DocumentValidatorConfiguration.SeriesLength}");

        RuleFor(cti => cti.Num)
            .Length(DocumentValidatorConfiguration.NumLength)
            .WithMessage($"Length for Num - {DocumentValidatorConfiguration.NumLength}");

        RuleFor(cti => cti.PINFL)
            .Length(DocumentValidatorConfiguration.PinflLength)
            .WithMessage($"Length for PINFL - {DocumentValidatorConfiguration.PinflLength}");
    }
}
