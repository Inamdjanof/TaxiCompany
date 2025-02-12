using AutoMapper;
using TaxiCompany.Application.Models.Insurance;
using TaxiCompany.Core.Entities;

namespace TaxiCompany.Application.MappingProfiles;

public class InsuranceProfile : Profile
{
    public InsuranceProfile()
    {

        CreateMap<CreateInsuranceModel, Insurance>();

        CreateMap<Insurance, InsuranceResponseModel>();

    }
}
