using AutoMapper;
using TaxiCompany.Application.Models.Person;
using TaxiCompany.Core.Entities;

namespace TaxiCompany.Application.MappingProfiles;

public class PersonProfile : Profile
{
    public PersonProfile()
    {

        CreateMap<CreatePersonModel, Person>();

        CreateMap<Person, PersonResponseModel>();

    }
}
