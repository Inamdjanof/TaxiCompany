namespace TaxiCompany.Application.Models.Insurance;

public class InsuranceResponseModel : BaseResponseModel
{
    public string Num { get; set; }

    public DateOnly TermYear { get; set; }
}
