using AutoMapper;
using TaxiCompany.Application.Models.Impressions;
using TaxiCompany.Application.Models;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Repositories;
using TaxiCompany.Application.Models.Insurance;

namespace TaxiCompany.Application.Services.Impl;

public class InsuranceService : IInsuranceService
{
    private readonly IMapper _mapper;
    private readonly IInsuranceRepository _insuranceRepository;
    private readonly ICarRepository _carRepository;

    public InsuranceService(IMapper mapper,
        IInsuranceRepository insuranceRepository,
        ICarRepository carRepository)
    {
        _mapper = mapper;
        _insuranceRepository = insuranceRepository;
        _carRepository = carRepository;
    }

    public async Task<IEnumerable<InsuranceResponseModel>> GetByCarIdAsync(Guid id)
    {
        var insurance = await _insuranceRepository.GetAllAsync(cti => cti.Car.Id == id);

        return _mapper.Map<IEnumerable<InsuranceResponseModel>>(insurance);
    }

    public async Task<CreateInsuranceResponseModel> CreateAsync(CreateInsuranceModel createInsuranceModel)
    {
        var car = await _carRepository.GetFirstAsync(cti => cti.Id == createInsuranceModel.CarId);

        var insurance = _mapper.Map<Insurance>(createInsuranceModel);
        insurance.Car = car;

        return new CreateInsuranceResponseModel()
        {
            Id = (await _insuranceRepository.AddAsync(insurance)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var insurance = await _insuranceRepository.GetFirstAsync(cti => cti.Id == id);

        return new BaseResponseModel()
        {
            Id = (await _insuranceRepository.DeleteAsync(insurance)).Id
        };
    }
}
