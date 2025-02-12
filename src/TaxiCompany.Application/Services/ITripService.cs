using TaxiCompany.Application.Models;
using TaxiCompany.Application.Models.Trip;

namespace TaxiCompany.Application.Services;

public interface ITripService
{
    Task<CreateTripResponseModel> CreateAsync(CreateTripModel createTripModel);
    Task<BaseResponseModel> DeleteAsync(Guid id);
    Task<IEnumerable<TripResponseModel>> GetAllByClientIdAndPersonId(Guid clientId, Guid carId);
    Task<UpdateTripResponseModel> UpdateAsync(Guid id, UpdateTripModel updateTripModel);
}
