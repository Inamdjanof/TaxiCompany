namespace TaxiCompany.Application.Models.Role;

public class CreateRoleModel
{
    public string Name { get; set; }

    public int? Level { get; set; }

    public decimal Salary { get; set; }

    public string Description { get; set; }
}

public class CreateRoleResponseModel : BaseResponseModel { }