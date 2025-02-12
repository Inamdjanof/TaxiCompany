using TaxiCompany.Core.Enums;

namespace TaxiCompany.Application.Models.Trip;

public class UpdateTripModel
{
    public string EndLocation { get; set; }

    public DateTime EndTime { get; set; }

    public decimal Cost { get; set; }

    public PaymentType PaymentType { get; set; }

    public Status Status { get; set; }

    public Guid Impressions { get; set; }
}
public class UpdateTripResponseModel : BaseResponseModel { }
