namespace TaxiCompany.Application.Models.Impressions;

public class ImpressionsResponseModel : BaseResponseModel
{
    public short Stars { get; set; }

    public string? Review { get; set; }

    public bool? CleanInterior { get; set; }

    public bool? CleanCar { get; set; }

    public bool? Politeness { get; set; }

    public bool? SmoothDriving { get; set; }
}
