namespace TaxiCompany.Application.Models.CarsOwner;

public class CreateCarsOwnerModel
{
    public Guid PersonId { get; set; }

    public decimal CompanyWallet { get; set; }
}

public class CreateCarsOwnerResponseModel : BaseResponseModel { }