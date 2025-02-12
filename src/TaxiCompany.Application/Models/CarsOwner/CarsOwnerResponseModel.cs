namespace TaxiCompany.Application.Models.CarsOwner;

public class CarsOwnerResponseModel : BaseResponseModel
{
    public short Priority { get; set; } = 100;

    public decimal Rating { get; set; } = 5.00m;

    public decimal CompanyWallet { get; set; }
}
