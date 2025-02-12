using AutoMapper;
using TaxiCompany.Application.Models.Insurance;
using TaxiCompany.Application.Models;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Repositories;
using TaxiCompany.DataAccess.Repositories.Impl;
using TaxiCompany.Application.Models.Role;
using TaxiCompany.Application.Models.Person;

namespace TaxiCompany.Application.Services.Impl;

public class RoleService : IRoleService
{
    private readonly IMapper _mapper;
    private readonly IRoleRepository _roleRepository;

    public RoleService(IMapper mapper,
        IRoleRepository roleRepository)
    {
        _mapper = mapper;
        _roleRepository = roleRepository;
    }

    public async Task<IEnumerable<RoleResponseModel>> GetByIdAsync(Guid id)
    {
        var role = await _roleRepository.GetAllAsync(cti => cti.Id == id);

        return _mapper.Map<IEnumerable<RoleResponseModel>>(role);
    }

    public async Task<CreateRoleResponseModel> CreateAsync(CreateRoleModel createRoleModel)
    {
        var role = _mapper.Map<Role>(createRoleModel);

        return new CreateRoleResponseModel()
        {
            Id = (await _roleRepository.AddAsync(role)).Id
        };
    }

    public async Task<UpdateRoleResponseModel> UpdateAsync(Guid id, UpdateRoleModel updateRoleModel)
    {
        var role = await _roleRepository.GetFirstAsync(cti => cti.Id == id);
        _mapper.Map(role, updateRoleModel);

        return new UpdateRoleResponseModel()
        {
            Id = (await _roleRepository.UpdateAsync(role)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var role = await _roleRepository.GetFirstAsync(cti => cti.Id == id);

        return new BaseResponseModel()
        {
            Id = (await _roleRepository.DeleteAsync(role)).Id
        };
    }
}
