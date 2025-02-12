namespace TaxiCompany.Application.Models.Card;

public class UpdateCardModel
{
    public bool IsVerified { get; set; }

    public decimal Balance { get; set; }
}

public class UpdateCardResponseModel : BaseResponseModel { }
