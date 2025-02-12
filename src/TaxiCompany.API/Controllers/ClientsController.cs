using Microsoft.AspNetCore.Mvc;
using TaxiCompany.Application.Models.Client;
using TaxiCompany.Application.Models;
using TaxiCompany.Application.Services;

namespace TaxiCompany.API.Controllers;

public class ClientsController : ApiController
{
    private readonly IClientService _clientService;

    public ClientsController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBanksAsync(Guid id)
    {
        return Ok(ApiResult<IEnumerable<ClientResponseModel>>.Success(
            await _clientService.GetAllByPersonIdAsync(id)));
    }

    [HttpPost]
    
    public async Task<IActionResult> CreateAsync(CreateClientModel createClientModel)
    {
        return Ok(ApiResult<CreateClientResponseModel>.Success(
            await _clientService.CreateAsync(createClientModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateClientModel updateClientModel)
    {
        return Ok(ApiResult<UpdateClientResponseModel>.Success(
            await _clientService.UpdateAsync(id, updateClientModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _clientService.DeleteAsync(id)));
    }

}
