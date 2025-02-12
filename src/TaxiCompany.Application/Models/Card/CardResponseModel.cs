namespace TaxiCompany.Application.Models.Card;

public class CardResponseModel : BaseResponseModel
{

    public string Num { get; set; }

    public string Term { get; set; }

    public bool IsVerified { get; set; }

    public decimal Balance { get; set; }

}
