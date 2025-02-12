using AutoMapper;
using TaxiCompany.Application.Models.Bank;
using TaxiCompany.Application.Models.Card;
using TaxiCompany.Application.Models;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Repositories;
using TaxiCompany.DataAccess.Repositories.Impl;
using TaxiCompany.Application.Models.Car;
using TaxiCompany.Application.Models.CarsOwner;

namespace TaxiCompany.Application.Services.Impl;

public class CarService : ICarService
{
    private readonly IMapper _mapper;
    private readonly ICarRepository _carRepository;
    private readonly ICarsOwnerRepository _carsOwnerRepository;
    private readonly ICompanyRepository _companyRepository;

    public CarService(IMapper mapper,
        ICarRepository carRepository,
        ICarsOwnerRepository carsOwnerRepository,
        ICompanyRepository companyRepository)
    {
        _mapper = mapper;
        _carRepository = carRepository;
        _carsOwnerRepository = carsOwnerRepository;
        _companyRepository = companyRepository;
    }


    public async Task<CarResponseModel> GetCarById(Guid id)
    {
        var car = _carRepository.GetFirstAsync(cti => cti.Id == id);

        return _mapper.Map<CarResponseModel>(car);
    }


    public async Task<CreateCarResponseModel> CreateAsync(CreateCarModel createCarModel,
        CancellationToken cancellationToken = default)
    {
        var carsOwner = await _carsOwnerRepository.GetFirstAsync(cti => cti.Id == createCarModel.OwnersId);

        var car = _mapper.Map<Car>(createCarModel);
        car.CarsOwner = carsOwner;

        return new CreateCarResponseModel
        {
            Id = (await _carRepository.AddAsync(car)).Id
        };
    }


   
    public async Task<UpdateCarResponseModel> UpdateAsync(Guid id, UpdateCarModel updateCardModel,
        CancellationToken cancellationToken = default)
    {
        var car = await _carRepository.GetFirstAsync(cti => cti.Id == id);

        _mapper.Map(updateCardModel, car);

        return new UpdateCarResponseModel
        {
            Id = (await _carRepository.UpdateAsync(car)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var car = await _carRepository.GetFirstAsync(ti => ti.Id == id);

        return new BaseResponseModel
        {
            Id = (await _carRepository.DeleteAsync(car)).Id
        };
    }



}
