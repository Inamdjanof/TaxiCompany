namespace TaxiCompany.Application.Models.Company;

public class UpdateCompanyModel
{
    public string Name { get; set; }

    public decimal Comission { get; set; }

    public Guid BankId { get; set; }

}
public class UpdateCompanyResponseModel : BaseResponseModel { }