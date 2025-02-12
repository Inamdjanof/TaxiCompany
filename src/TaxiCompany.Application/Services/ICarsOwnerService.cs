using TaxiCompany.Application.Models;
using TaxiCompany.Application.Models.CarsOwner;

namespace TaxiCompany.Application.Services;

public interface ICarsOwnerService
{
    Task<CreateCarsOwnerResponseModel> CreateAsync(CreateCarsOwnerModel createCarsOwnerModel, CancellationToken cancellationToken = default);
    Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<CarsOwnerResponseModel>> GetAllByPersonIdAsync(Guid id);
}
