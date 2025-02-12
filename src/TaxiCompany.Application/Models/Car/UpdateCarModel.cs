namespace TaxiCompany.Application.Models.Car;

public class UpdateCarModel
{
    public bool IsFree { get; set; }

    public Guid OwnersId { get; set; }

}

public class UpdateCarResponseModel : BaseResponseModel { };
