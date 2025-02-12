using TaxiCompany.Application.Models.Authentication;

namespace TaxiCompany.Application.Services;

public interface IAuthenticationService
{
    Task<TokenDto> LoginAsync(AuthenticationDto authenticationDto);
    Task<TokenDto> RefreshTokenAsync(RefreshTokenDto refreshTokenDto);
}