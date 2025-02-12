using TaxiCompany.Core.Enums;

namespace TaxiCompany.Application.Models.Trip;

public class CreateTripModel
{
    public Guid ClientId { get; set; }

    public Guid CarId { get; set; }

    public string StartLocation { get; set; }

    public decimal Cost { get; set; }

    public PaymentType PaymentType { get; set; }
}
public class CreateTripResponseModel : BaseResponseModel { }
