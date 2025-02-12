using TaxiCompany.Application.Models;
using TaxiCompany.Application.Models.Bank;

namespace TaxiCompany.Application.Services;

public interface IBankService
{
    Task<IEnumerable<BankResponseModel>> GetAllAsync();

    Task<CreateBankResponseModel> CreateAsync(CreateBankModel createBankModel,
        CancellationToken cancellationToken = default);

    Task<UpdateBankResponseModel> UpdateAsync(Guid id, UpdateBankModel updateBankModel,
        CancellationToken cancellationToken = default);

    Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
