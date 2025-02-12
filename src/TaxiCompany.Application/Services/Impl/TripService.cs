using AutoMapper;
using TaxiCompany.Application.Models.Insurance;
using TaxiCompany.Application.Models;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Repositories;
using TaxiCompany.Application.Models.Person;
using TaxiCompany.DataAccess.Repositories.Impl;
using TaxiCompany.Application.Models.Trip;

namespace TaxiCompany.Application.Services.Impl;

public class TripService : ITripService
{
    private readonly IMapper _mapper;
    private readonly ITripRepository _tripRepository;
    private readonly IClientRepository _clientRepository;
    private readonly ICarRepository _carRepository;

    public TripService(IMapper mapper, 
        ITripRepository tripRepository, 
        IClientRepository clientRepository, 
        ICarRepository carRepository)
    {
        _mapper = mapper;
        _tripRepository = tripRepository;
        _clientRepository = clientRepository;
        _carRepository = carRepository;
    }

    public async Task<IEnumerable<TripResponseModel>> GetAllByClientIdAndPersonId(Guid clientId, Guid carId)
    {
        var trips = await _tripRepository.GetAllAsync(cti => cti.Car.Id == carId && cti.Client.Id == clientId);

        return _mapper.Map<IEnumerable<TripResponseModel>>(trips);
    }

    public async Task<CreateTripResponseModel> CreateAsync(CreateTripModel createTripModel)
    {
        var car = await _carRepository.GetFirstAsync(cti => cti.Id == createTripModel.CarId);
        var client = await _clientRepository.GetFirstAsync(cti => cti.Id == createTripModel.ClientId);

        var trip = _mapper.Map<Trip>(createTripModel);
        trip.Car = car;
        trip.Client = client;

        return new CreateTripResponseModel()
        {
            Id = (await _tripRepository.AddAsync(trip)).Id
        };
    }


    public async Task<UpdateTripResponseModel> UpdateAsync(Guid id, UpdateTripModel updateTripModel)
    {
        var trip = await _tripRepository.GetFirstAsync(cti => cti.Id == id);
        _mapper.Map(trip, updateTripModel);

        return new UpdateTripResponseModel()
        {
            Id = (await _tripRepository.UpdateAsync(trip)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var trip = await _tripRepository.GetFirstAsync(cti => cti.Id == id);

        return new BaseResponseModel()
        {
            Id = (await _tripRepository.DeleteAsync(trip)).Id
        };
    }
}
