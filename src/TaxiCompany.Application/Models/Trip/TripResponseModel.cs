using TaxiCompany.Core.Enums;

namespace TaxiCompany.Application.Models.Trip;

public class TripResponseModel : BaseResponseModel
{
    public string StartLocation { get; set; }

    public string? EndLocation { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public decimal Cost { get; set; } = 0;

    public PaymentType PaymentType { get; set; }

    public Status Status { get; set; }
}
