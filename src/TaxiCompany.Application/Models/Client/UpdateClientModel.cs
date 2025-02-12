namespace TaxiCompany.Application.Models.Client;

public class UpdateClientModel
{
    public bool SubscriptionStatus { get; set; } = false;

    public decimal AccountWallet { get; set; }
}
public class UpdateClientResponseModel : BaseResponseModel { }
