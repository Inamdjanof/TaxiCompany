using AutoMapper;
using TaxiCompany.Application.Models.Impressions;
using TaxiCompany.Application.Models;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Repositories;
using TaxiCompany.Application.Models.Person;

namespace TaxiCompany.Application.Services.Impl;

public class PersonService : IPersonService
{
    private readonly IMapper _mapper;
    private readonly IPersonRepository _personRepository;

    public PersonService(IMapper mapper,
        IPersonRepository personRepository)
    {
        _mapper = mapper;
        _personRepository = personRepository;
    }

    public async Task<IEnumerable<PersonResponseModel>> GetById(Guid id)
    {
        var person = await _personRepository.GetAllAsync(cti => cti.Id == id);

        return _mapper.Map<IEnumerable<PersonResponseModel>>(person);
    }

    public async Task<CreatePersonResponseModel> CreateAsync(CreatePersonModel createPersonModel)
    {
        var person = _mapper.Map<Person>(createPersonModel);

        return new CreatePersonResponseModel()
        {
            Id = (await _personRepository.AddAsync(person)).Id
        };
    }

    public async Task<UpdatePersonResponseModel> UpdateAsync(Guid id, UpdatePersonModel _updatePersonModel)
    {
        var person = await _personRepository.GetFirstAsync(cti => cti.Id == id);
        _mapper.Map(person, _updatePersonModel);

        return new UpdatePersonResponseModel()
        {
            Id = (await _personRepository.UpdateAsync(person)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var person = await _personRepository.GetFirstAsync(cti => cti.Id == id);

        return new BaseResponseModel()
        {
            Id = (await _personRepository.DeleteAsync(person)).Id
        };
    }
}
