using TaxiCompany.Application.Models;
using TaxiCompany.Application.Models.Employee;

namespace TaxiCompany.Application.Services;

public interface IEmployeeService
{
    Task<CreateEmployeeResponseModel> CreateAsync(CreateEmployeeModel createEmployeeModel);
    Task<BaseResponseModel> DeleteAsync(Guid id);
    Task<IEnumerable<EmployeeResponseModel>> GetAll();
    Task<UpdateEmployeeResponseModel> UpdateAsync(Guid id, UpdateEmployeeModel updateEmployeeModel);
}
