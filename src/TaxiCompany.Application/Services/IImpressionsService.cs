using TaxiCompany.Application.Models;
using TaxiCompany.Application.Models.Impressions;

namespace TaxiCompany.Application.Services;

public interface IImpressionsService
{
    Task<CreateImpressionsResponseModel> CreateAsync(CreateImpressionsModel createImpressionsModel);
    Task<BaseResponseModel> DeleteAsync(Guid id);
    Task<IEnumerable<ImpressionsResponseModel>> GetByCarIdAsync(Guid id);
    Task<UpdateImpressionsResponseModel> UpdateAsync(Guid id, UpdateImpressionsModel updateImpressionsModel);
}
