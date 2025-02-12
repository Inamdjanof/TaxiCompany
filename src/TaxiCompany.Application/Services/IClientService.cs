using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCompany.Application.Models;
using TaxiCompany.Application.Models.Client;

namespace TaxiCompany.Application.Services;

public interface IClientService
{
    Task<CreateClientResponseModel> CreateAsync(CreateClientModel createClientModel, CancellationToken cancellationToken = default);
    Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<ClientResponseModel>> GetAllByPersonIdAsync(Guid id);
    Task<UpdateClientResponseModel> UpdateAsync(Guid id, UpdateClientModel updateClientModel, CancellationToken cancellationToken = default);
}
