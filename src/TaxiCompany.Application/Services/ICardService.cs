using TaxiCompany.Application.Models;
using TaxiCompany.Application.Models.Card;
using TaxiCompany.Application.Models.CarsOwner;

namespace TaxiCompany.Application.Services;

public interface ICardService
{
    Task<IEnumerable<CardResponseModel>> GetAllByPersonIdAsync(Guid id);

    Task<CreateCardResponseModel> CreateAsync(CreateCardModel createCardModel, CancellationToken cancellationToken = default);
    
    Task<UpdateCardResponseModel> UpdateAsync(Guid id, UpdateCarsOwnerModel updateCardModel,
        CancellationToken cancellationToken = default);
    
    Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}