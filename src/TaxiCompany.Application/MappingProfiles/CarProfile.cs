using AutoMapper;
using TaxiCompany.Application.Models.Car;
using TaxiCompany.Core.Entities;

namespace TaxiCompany.Application.MappingProfiles;

public class CarProfile : Profile
{
    public CarProfile()
    {

        CreateMap<CreateCarModel, Car>();

        CreateMap<Card, CarResponseModel>();

    }
}
