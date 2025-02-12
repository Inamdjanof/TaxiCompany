using AutoMapper;
using TaxiCompany.Application.Models.Employee;
using TaxiCompany.Core.Entities;

namespace TaxiCompany.Application.MappingProfiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {

        CreateMap<CreateEmployeeModel, Employee>();

        CreateMap<Employee, EmployeeResponseModel>();

    }
}
