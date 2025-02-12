namespace TaxiCompany.Application.Models.Car;

public class CreateCarModel
{
    public string Model { get; set; }

    public Guid OwnersId { get; set; }

}

public class CreateCarResponseModel : BaseResponseModel { };
