using Microsoft.AspNetCore.Mvc;
using TaxiCompany.Application.Models.Car;
using TaxiCompany.Application.Models;
using TaxiCompany.Application.Services;

namespace TaxiCompany.API.Controllers;

public class CarsController : ApiController
{
    private readonly ICarService _carService;

    public CarsController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBanksAsync(Guid id)
    {
        return Ok(ApiResult<CarResponseModel>.Success(
            await _carService.GetCarById(id)));
    }

    [HttpPost]
 
    public async Task<IActionResult> CreateAsync(CreateCarModel createCarModel)
    {
        return Ok(ApiResult<CreateCarResponseModel>.Success(
            await _carService.CreateAsync(createCarModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateCarModel updateCarModel)
    {
        return Ok(ApiResult<UpdateCarResponseModel>.Success(
            await _carService.UpdateAsync(id,updateCarModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _carService.DeleteAsync(id)));
    }
}
