using Microsoft.AspNetCore.Mvc;
using TaxiCompany.Application.Models.Employee;
using TaxiCompany.Application.Models;
using TaxiCompany.Application.Services;

namespace TaxiCompany.API.Controllers;

public class EmployeesController : ApiController
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBanksAsync()
    {
        return Ok(ApiResult<IEnumerable<EmployeeResponseModel>>.Success(
            await _employeeService.GetAll()));
    }

    [HttpPost]
    //[AllowAnonymous]
    public async Task<IActionResult> CreateAsync(CreateEmployeeModel createEmployeeModel)
    {
        return Ok(ApiResult<CreateEmployeeResponseModel>.Success(
            await _employeeService.CreateAsync(createEmployeeModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateEmployeeModel updateEmployeeModel)
    {
        return Ok(ApiResult<UpdateEmployeeResponseModel>.Success(
            await _employeeService.UpdateAsync(id, updateEmployeeModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _employeeService.DeleteAsync(id)));
    }
}
