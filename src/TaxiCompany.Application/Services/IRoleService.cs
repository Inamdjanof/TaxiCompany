using TaxiCompany.Application.Models;
using TaxiCompany.Application.Models.Role;

namespace TaxiCompany.Application.Services;

public interface IRoleService
{
    Task<CreateRoleResponseModel> CreateAsync(CreateRoleModel createRoleModel);
    Task<BaseResponseModel> DeleteAsync(Guid id);
    Task<IEnumerable<RoleResponseModel>> GetByIdAsync(Guid id);
    Task<UpdateRoleResponseModel> UpdateAsync(Guid id, UpdateRoleModel updateRoleModel);
}
