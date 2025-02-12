using TaxiCompany.Application.Common.Email;

namespace TaxiCompany.Application.Services;

public interface IEmailService
{
    Task SendEmailAsync(EmailMessage emailMessage);
}
