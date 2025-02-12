namespace TaxiCompany.Application.Models.Client;

public class ClientResponseModel : BaseResponseModel
{
    public bool SubscriptionStatus { get; set; } = false;

    public decimal? AccountWallet { get; set; }
}
