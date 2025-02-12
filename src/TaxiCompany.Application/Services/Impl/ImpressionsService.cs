using AutoMapper;
using TaxiCompany.Application.Models.Employee;
using TaxiCompany.Application.Models;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Repositories;
using TaxiCompany.Application.Models.Impressions;

namespace TaxiCompany.Application.Services.Impl;

public class ImpressionsService : IImpressionsService
{
    private readonly IMapper _mapper;
    private readonly IImpressionsRepository _impressionsRepository;
    private readonly ICarRepository _carRepository;

    public ImpressionsService(IMapper mapper,
        IImpressionsRepository impressionsRepository,
        ICarRepository carRepository)
    {
        _mapper = mapper;
        _impressionsRepository = impressionsRepository;
        _carRepository = carRepository;
    }

    public async Task<IEnumerable<ImpressionsResponseModel>> GetByCarIdAsync(Guid id)
    {
        var impressions = await _impressionsRepository.GetAllAsync(cti => cti.Car.Id == id);

        return _mapper.Map<IEnumerable<ImpressionsResponseModel>>(impressions);
    }

    public async Task<CreateImpressionsResponseModel> CreateAsync(CreateImpressionsModel createImpressionsModel)
    {
        var car = await _carRepository.GetFirstAsync(cti => cti.Id == createImpressionsModel.CarId);

        var impressions = _mapper.Map<Impressions>(createImpressionsModel);
        impressions.Car = car;

        return new CreateImpressionsResponseModel()
        {
            Id = (await _impressionsRepository.AddAsync(impressions)).Id
        };
    }

    public async Task<UpdateImpressionsResponseModel> UpdateAsync(Guid id, UpdateImpressionsModel updateImpressionsModel)
    {
        var impressions = await _impressionsRepository.GetFirstAsync(cti => cti.Id == id);
        _mapper.Map(impressions, updateImpressionsModel);

        return new UpdateImpressionsResponseModel()
        {
            Id = (await _impressionsRepository.UpdateAsync(impressions)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var impressions = await _impressionsRepository.GetFirstAsync(cti => cti.Id == id);

        return new BaseResponseModel()
        {
            Id = (await _impressionsRepository.DeleteAsync(impressions)).Id
        };
    }
}
