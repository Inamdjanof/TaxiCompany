namespace TaxiCompany.Application.Models.Insurance;

public class CreateInsuranceModel
{
    public string Num { get; set; }

    public DateOnly TermYear { get; set; }

    public Guid CarId { get; set; }
}
public class CreateInsuranceResponseModel : BaseResponseModel { }
