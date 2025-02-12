using TaxiCompany.Application.Models;
using TaxiCompany.Application.Models.Person;

namespace TaxiCompany.Application.Services;

public interface IPersonService
{
    Task<CreatePersonResponseModel> CreateAsync(CreatePersonModel createPersonModel);
    Task<BaseResponseModel> DeleteAsync(Guid id);
    Task<IEnumerable<PersonResponseModel>> GetById(Guid id);
    Task<UpdatePersonResponseModel> UpdateAsync(Guid id, UpdatePersonModel _updatePersonModel);
}
