namespace TaxiCompany.Application.Models.Role;

public class RoleResponseModel : BaseResponseModel
{
    public string Name { get; set; }

    public short? Level { get; set; }

    public decimal Salary { get; set; }

    public string Description { get; set; }
}
