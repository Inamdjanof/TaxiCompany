using TaxiCompany.Core.Enums;

namespace TaxiCompany.Application.Models.Users;

public record UserDto(
    Guid id,
    string firstName,
    string lastName,
    string email,
    UserRole role);