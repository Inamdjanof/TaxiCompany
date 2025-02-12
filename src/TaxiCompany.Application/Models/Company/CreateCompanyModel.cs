namespace TaxiCompany.Application.Models.Company;

public class CreateCompanyModel
{
    public string Name { get; set; }

    public decimal Comission { get; set; }

    public Guid BankId { get; set; }

}
public class CreateCompanyResponseModel : BaseResponseModel { }

