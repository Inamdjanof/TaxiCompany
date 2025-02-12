using Microsoft.AspNetCore.Mvc;
using TaxiCompany.Application.Models.Insurance;
using TaxiCompany.Application.Models;
using TaxiCompany.Application.Services;

namespace TaxiCompany.API.Controllers;

public class InsurancesController : ApiController
{
    private readonly IInsuranceService _insuranceService;

    public InsurancesController(IInsuranceService insuranceService)
    {
        _insuranceService = insuranceService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBanksAsync(Guid id)
    {
        return Ok(ApiResult<IEnumerable<InsuranceResponseModel>>.Success(
            await _insuranceService.GetByCarIdAsync(id)));
    }

    [HttpPost]
    
    public async Task<IActionResult> CreateAsync(CreateInsuranceModel createInsuranceModel)
    {
        return Ok(ApiResult<CreateInsuranceResponseModel>.Success(
            await _insuranceService.CreateAsync(createInsuranceModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _insuranceService.DeleteAsync(id)));
    }

}
