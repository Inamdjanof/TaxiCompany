using AutoMapper;
using TaxiCompany.Application.Models.Trip;
using TaxiCompany.Core.Entities;

namespace TaxiCompany.Application.MappingProfiles;

public class TripProfile : Profile
{
    public TripProfile()
    {

        CreateMap<CreateTripModel, Trip>();

        CreateMap<Trip, TripResponseModel>();

    }
}
