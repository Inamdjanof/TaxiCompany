using TaxiCompany.Application.Models;
using TaxiCompany.Application.Models.Company;

namespace TaxiCompany.Application.Services;

public interface ICompanyService
{
    Task<CreateCompanyResponseModel> CreateAsync(CreateCompanyModel createCompanyModel);
    Task<BaseResponseModel> DeleteAsync(Guid id);
    Task<IEnumerable<CompanyResponseModel>> GetAll();
    Task<UpdateCompanyResponseModel> UpdateAsync(Guid id, UpdateCompanyModel updateCompanyModel);
}
