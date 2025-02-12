using AutoMapper;
using TaxiCompany.Application.Models.Company;
using TaxiCompany.Core.Entities;

namespace TaxiCompany.Application.MappingProfiles;

public class CompanyProfile : Profile
{
    public CompanyProfile()
    {

        CreateMap<CreateCompanyModel, Company>();

        CreateMap<Company, CompanyResponseModel>();

    }
}
