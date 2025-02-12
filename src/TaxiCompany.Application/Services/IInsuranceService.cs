using TaxiCompany.Application.Models;
using TaxiCompany.Application.Models.Insurance;

namespace TaxiCompany.Application.Services;

public interface IInsuranceService
{
    Task<CreateInsuranceResponseModel> CreateAsync(CreateInsuranceModel createInsuranceModel);
    Task<BaseResponseModel> DeleteAsync(Guid id);
    Task<IEnumerable<InsuranceResponseModel>> GetByCarIdAsync(Guid id);
}
