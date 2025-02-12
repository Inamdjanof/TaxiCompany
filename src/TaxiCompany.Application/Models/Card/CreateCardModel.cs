namespace TaxiCompany.Application.Models.Card;

public class CreateCardModel
{
    public Guid BankId { get; set; }

    public string Num { get; set; }

    public string Term { get; set; }

    public decimal Balance { get; set; }

    public Guid PersonId { get; set; }

}

public class CreateCardResponseModel : BaseResponseModel { }
