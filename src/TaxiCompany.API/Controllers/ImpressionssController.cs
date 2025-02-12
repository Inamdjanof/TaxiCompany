using Microsoft.AspNetCore.Mvc;
using TaxiCompany.Application.Models.Impressions;
using TaxiCompany.Application.Models;
using TaxiCompany.Application.Services;

namespace TaxiCompany.API.Controllers;

public class ImpressionssController : ApiController
{
    private readonly IImpressionsService _impressionsService;

    public ImpressionssController(IImpressionsService impressionsService)
    {
        _impressionsService = impressionsService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllBanksAsync(Guid id)
    {
        return Ok(ApiResult<IEnumerable<ImpressionsResponseModel>>.Success(
            await _impressionsService.GetByCarIdAsync(id)));
    }

    [HttpPost]
   
    public async Task<IActionResult> CreateAsync(CreateImpressionsModel createImpressionsModel)
    {
        return Ok(ApiResult<CreateImpressionsResponseModel>.Success(
            await _impressionsService.CreateAsync(createImpressionsModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateImpressionsModel updateImpressionsModel)
    {
        return Ok(ApiResult<UpdateImpressionsResponseModel>.Success(
            await _impressionsService.UpdateAsync(id, updateImpressionsModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _impressionsService.DeleteAsync(id)));
    }
}
