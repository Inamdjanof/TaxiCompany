using AutoMapper;
using TaxiCompany.Application.Models.Client;
using TaxiCompany.Core.Entities;

namespace TaxiCompany.Application.MappingProfiles;

public class ClientProfile : Profile
{
    public ClientProfile()
    {

        CreateMap<CreateClientModel, Client>();

        CreateMap<Client, ClientResponseModel>();

    }
}
