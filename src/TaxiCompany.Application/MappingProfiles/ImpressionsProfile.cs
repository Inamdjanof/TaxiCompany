using AutoMapper;
using TaxiCompany.Application.Models.Impressions;
using TaxiCompany.Core.Entities;

namespace TaxiCompany.Application.MappingProfiles;

public class ImpressionsProfile : Profile
{
    public ImpressionsProfile()
    {

        CreateMap<CreateImpressionsModel, Impressions>();

        CreateMap<Impressions, ImpressionsResponseModel>();

    }
}
