using Microsoft.AspNetCore.Mvc;
using TaxiCompany.Application.Models.Card;
using TaxiCompany.Application.Models;
using TaxiCompany.Application.Services;

namespace TaxiCompany.API.Controllers;

public class CardsController : ApiController
{
    private readonly ICardService _cardService;

    public CardsController(ICardService cardService)
    {
        _cardService = cardService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBanksAsync(Guid id)
    {
        return Ok(ApiResult<IEnumerable<CardResponseModel>>.Success(
            await _cardService.GetAllByPersonIdAsync(id)));
    }

    [HttpPost]
    //[AllowAnonymous]
    public async Task<IActionResult> CreateAsync(CreateCardModel createCardModel)
    {
        return Ok(ApiResult<CreateCardResponseModel>.Success(
            await _cardService.CreateAsync(createCardModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(
            await _cardService.DeleteAsync(id)));
    }
}
