namespace TaxiCompany.Application.Models.Employee;

public class UpdateEmployeeModel
{
    public DateTime? DismissalDate { get; set; }

    public Guid RoleId { get; set; }
}

public class UpdateEmployeeResponseModel : BaseResponseModel { }
