namespace TaxiCompany.DataAccess.Authentication;

public class JwtOption
{
   
    public string SecretKey { get; set; }
    public int ExpirationInMinutes { get; set; } = 1440;
}