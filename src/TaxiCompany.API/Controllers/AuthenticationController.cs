using Microsoft.AspNetCore.Mvc;
using TaxiCompany.Application.Models.Authentication;
using TaxiCompany.Application.Services;

namespace TaxiCompany.API.Controllers;


public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(
        IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("Login")]
    public async ValueTask<ActionResult<TokenDto>> LoginAsync(
        AuthenticationDto authenticationDto)
    {
        TokenDto tokenDto = await _authenticationService
            .LoginAsync(authenticationDto);

        return Ok(tokenDto);
    }

   
}
