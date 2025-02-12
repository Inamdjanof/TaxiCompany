using AutoMapper;
using TaxiCompany.Application.Models;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Repositories;
using TaxiCompany.Application.Models.Client;

namespace TaxiCompany.Application.Services.Impl;

public class ClientService : IClientService
{
    private readonly IMapper _mapper;
    private readonly IClientRepository _clientRepository;
    private readonly IPersonRepository _personRepository;

    public ClientService(IMapper mapper,
        IClientRepository clientRepository,
        IPersonRepository personRepository)
    {
        _mapper = mapper;
        _clientRepository = clientRepository;
        _personRepository = personRepository;
    }
    public async Task<IEnumerable<ClientResponseModel>> GetAllByPersonIdAsync(Guid id)
    {
        var client = await _clientRepository.GetAllAsync(cti => cti.Person.Id == id);

        return _mapper.Map<IEnumerable<ClientResponseModel>>(client);
    }


    public async Task<CreateClientResponseModel> CreateAsync(CreateClientModel createClientModel,
        CancellationToken cancellationToken = default)
    {
        var person = await _personRepository.GetFirstAsync(cti => cti.Id == createClientModel.PersonId);

        var client = _mapper.Map<Client>(createClientModel);
        client.Person = person;

        return new CreateClientResponseModel
        {
            Id = (await _clientRepository.AddAsync(client)).Id
        };
    }

    public async Task<UpdateClientResponseModel> UpdateAsync(Guid id, UpdateClientModel updateClientModel,
        CancellationToken cancellationToken = default)
    {
        var client = await _clientRepository.GetFirstAsync(cti => cti.Id == id);

        _mapper.Map(updateClientModel, client);

        return new UpdateClientResponseModel
        {
            Id = (await _clientRepository.UpdateAsync(client)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var client = await _clientRepository.GetFirstAsync(ti => ti.Id == id);

        return new BaseResponseModel
        {
            Id = (await _clientRepository.DeleteAsync(client)).Id
        };
    }
}
