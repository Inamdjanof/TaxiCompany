using Microsoft.AspNetCore.Mvc;
using TaxiCompany.Application.Models.CarsOwner;
using TaxiCompany.Application.Models;
using TaxiCompany.Application.Services;
using TaxiCompany.Application.Services.Impl;

namespace TaxiCompany.API.Controllers;

public class CarsOwnersController : ApiController
{
    private readonly ICarsOwnerService _carsOwnerService;

    public CarsOwnersController(ICarsOwnerService carsOwnerService)
    {
        _carsOwnerService = carsOwnerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBanksAsync(Guid id)
    {
        return Ok(ApiResult<IEnumerable<CarsOwnerResponseModel>>.Success(
            await _carsOwnerService.GetAllByPersonIdAsync(id)));
    }

    [HttpPost]
   
    public async Task<IActionResult> CreateAsync(CreateCarsOwnerModel createCarsOwnerModel)
    {
        return Ok(ApiResult<CreateCarsOwnerResponseModel>.Success(
            await _carsOwnerService.CreateAsync(createCarsOwnerModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _carsOwnerService.DeleteAsync(id)));
    }
}
