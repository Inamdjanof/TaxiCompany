using AutoMapper;
using TaxiCompany.Application.Models.CarsOwner;
using TaxiCompany.Core.Entities;

namespace TaxiCompany.Application.MappingProfiles;

public class CarsOwnerProfile : Profile
{
    public CarsOwnerProfile()
    {

        CreateMap<CreateCarsOwnerModel, CarOwner>();

        CreateMap<CarOwner, CarsOwnerResponseModel>();

    }
}
