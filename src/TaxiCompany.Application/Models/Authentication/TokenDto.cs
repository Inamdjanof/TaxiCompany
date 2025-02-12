namespace TaxiCompany.Application.Models.Authentication;

public class TokenDto
{
    public string AccessToken { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime ExpireDate { get; set; }
}
   