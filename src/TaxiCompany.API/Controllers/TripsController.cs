using Microsoft.AspNetCore.Mvc;
using TaxiCompany.Application.Models.Trip;
using TaxiCompany.Application.Models;
using TaxiCompany.Application.Services;

namespace TaxiCompany.API.Controllers;

public class TripsController : ApiController
{
    private readonly ITripService _tripService;

    public TripsController(ITripService tripService)
    {
        _tripService = tripService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllBanksAsync(Guid clientId, Guid personId)
    {
        return Ok(ApiResult<IEnumerable<TripResponseModel>>.Success(
            await _tripService.GetAllByClientIdAndPersonId(clientId, personId)));
    }

    [HttpPost]
    
    public async Task<IActionResult> CreateAsync(CreateTripModel createTripModel)
    {
        return Ok(ApiResult<CreateTripResponseModel>.Success(
            await _tripService.CreateAsync(createTripModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateTripModel updateTripModel)
    {
        return Ok(ApiResult<UpdateTripResponseModel>.Success(
            await _tripService.UpdateAsync(id, updateTripModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _tripService.DeleteAsync(id)));
    }
}
