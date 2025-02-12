using AutoMapper;
using TaxiCompany.Application.Models.Role;
using TaxiCompany.Core.Entities;

namespace TaxiCompany.Application.MappingProfiles;

public class RoleProfile : Profile
{
    public RoleProfile()
    {

        CreateMap<CreateRoleModel, Role>();

        CreateMap<Role, RoleResponseModel>();

    }
}
