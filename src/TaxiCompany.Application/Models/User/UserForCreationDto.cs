namespace TaxiCompany.Application.Models.Users;

public record UserForCreationDto(
    string firstName,
    string? lastName,
    string email,
    string password);