namespace TaxiCompany.Application.Models.Users;

public record UserForModificationDto(
    Guid userId,
    string? firstName,
    string? lastName,
    string? phoneNumber);