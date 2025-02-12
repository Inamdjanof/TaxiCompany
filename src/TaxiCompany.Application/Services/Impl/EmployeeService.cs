using AutoMapper;
using TaxiCompany.Application.Models.Company;
using TaxiCompany.Application.Models;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Repositories;
using TaxiCompany.Application.Models.Employee;
using TaxiCompany.DataAccess.Repositories.Impl;

namespace TaxiCompany.Application.Services.Impl;

public class EmployeeService : IEmployeeService
{
    private readonly IMapper _mapper;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IPersonRepository _personRepository;
    private readonly IRoleRepository _roleRepository;

    public EmployeeService(IMapper mapper,
        IEmployeeRepository employeeRepository,
        IPersonRepository personRepository,
        IRoleRepository roleRepository)
    {
        _mapper = mapper;
        _employeeRepository = employeeRepository;
        _personRepository = personRepository;
        _roleRepository = roleRepository;
    }

    public async Task<IEnumerable<EmployeeResponseModel>> GetAll()
    {
        var employees = _employeeRepository.GetAllAsEnumurable();

        return _mapper.Map<IEnumerable<EmployeeResponseModel>>(employees);
    }

    public async Task<CreateEmployeeResponseModel> CreateAsync(CreateEmployeeModel createEmployeeModel)
    {
        var person = await _personRepository.GetFirstAsync(cti => cti.Id == createEmployeeModel.PersonId);
        var role = await _roleRepository.GetFirstAsync(cti => cti.Id == createEmployeeModel.RoleId);

        var employee = _mapper.Map<Employee>(createEmployeeModel);
        employee.Person = person;
        employee.Role = role;

        return new CreateEmployeeResponseModel()
        {
            Id = (await _employeeRepository.AddAsync(employee)).Id
        };
    }

    public async Task<UpdateEmployeeResponseModel> UpdateAsync(Guid id, UpdateEmployeeModel updateEmployeeModel)
    {
        var employee = await _employeeRepository.GetFirstAsync(cti => cti.Id == id);
        _mapper.Map(employee, updateEmployeeModel);

        return new UpdateEmployeeResponseModel()
        {
            Id = (await _employeeRepository.UpdateAsync(employee)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var company = await _employeeRepository.GetFirstAsync(cti => cti.Id == id);

        return new BaseResponseModel()
        {
            Id = (await _employeeRepository.DeleteAsync(company)).Id
        };
    }
}
