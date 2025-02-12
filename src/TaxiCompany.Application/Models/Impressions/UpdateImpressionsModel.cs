namespace TaxiCompany.Application.Models.Impressions;

public class UpdateImpressionsModel
{
    public int Stars { get; set; }

    public string? Review { get; set; }

    public bool? CleanInterior { get; set; }

    public bool? CleanCar { get; set; }

    public bool? Politeness { get; set; }

    public bool? SmoothDriving { get; set; }
}

public class UpdateImpressionsResponseModel : BaseResponseModel { }