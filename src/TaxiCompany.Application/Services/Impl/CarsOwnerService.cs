using TaxiCompany.Application.Models;
using TaxiCompany.Core.Entities;
using AutoMapper;
using TaxiCompany.DataAccess.Repositories;
using TaxiCompany.Application.Models.CarsOwner;

namespace TaxiCompany.Application.Services.Impl;

public class CarsOwnerService : ICarsOwnerService
{

    private IMapper _mapper;
    private ICarsOwnerRepository _carsOwnerRepository;
    private IPersonRepository _personRepository;

    public CarsOwnerService(IMapper mapper,
        ICarsOwnerRepository carsOwnerRepository,
        IPersonRepository personRepository)
    {
        _mapper = mapper;
        _carsOwnerRepository = carsOwnerRepository;
        _personRepository = personRepository;
    }

    public async Task<IEnumerable<CarsOwnerResponseModel>> GetAllByPersonIdAsync(Guid id)
    {
        var carsOwners = await _carsOwnerRepository.GetAllAsync(cti => cti.Person.Id == id);

        return _mapper.Map<IEnumerable<CarsOwnerResponseModel>>(carsOwners);
    }


    public async Task<CreateCarsOwnerResponseModel> CreateAsync(CreateCarsOwnerModel createCarsOwnerModel,
        CancellationToken cancellationToken = default)
    {
        var person = await _personRepository.GetFirstAsync(cti => cti.Id == createCarsOwnerModel.PersonId);

        var carsOwner = _mapper.Map<CarOwner>(createCarsOwnerModel);
        carsOwner.Person = person;

        return new CreateCarsOwnerResponseModel
        {
            Id = (await _carsOwnerRepository.AddAsync(carsOwner)).Id
        };
    }
    
    public async Task<UpdateCarsOwnerResponseModel> UpdateAsync(Guid id,UpdateCarsOwnerModel updateCardModel,
        CancellationToken cancellationToken = default)
    {
        var card = await _carsOwnerRepository.GetFirstAsync(cti => cti.Id == id);

        _mapper.Map(updateCardModel, card);

        return new UpdateCarsOwnerResponseModel
        {
            Id = (await _carsOwnerRepository.UpdateAsync(card)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var carsOwner = await _carsOwnerRepository.GetFirstAsync(ti => ti.Id == id);

        return new BaseResponseModel
        {
            Id = (await _carsOwnerRepository.DeleteAsync(carsOwner)).Id
        };
    }
}
