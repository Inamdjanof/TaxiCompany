using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxiCompany.Application.Commands.Banks;
using TaxiCompany.Application.Models;
using TaxiCompany.Application.Models.Bank;
using TaxiCompany.Application.Queries.Banks;
using TaxiCompany.Application.Services;

namespace TaxiCompany.API.Controllers;


public class BanksController : ApiController
{

    private readonly IMediator _mediator;

    public BanksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllBanksQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBankModel model)
    {
        var result = await _mediator.Send(new CreateBankCommand { Bank = model });
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBankModel model)
    {
        var result = await _mediator.Send(new UpdateBankCommand { Id = id, Bank = model });
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteBankCommand { Id = id });
        return Ok(result);
    }




    //private readonly IBankService _bankService;

    //public BanksController(IBankService bankService)
    //{
    //    _bankService = bankService;
    //}


    //[HttpGet]
    //public async Task<IActionResult> GetAllBanksAsync()
    //{
    //    return Ok(ApiResult<IEnumerable<BankResponseModel>>.Success(
    //        await _bankService.GetAllAsync()));
    //}

    //[HttpPost]
    //public async Task<IActionResult> CreateAsync(CreateBankModel createBankModel)
    //{
    //    return Ok(ApiResult<CreateBankResponseModel>.Success(
    //        await _bankService.CreateAsync(createBankModel)));
    //}



    //[HttpPut("{id:guid}")]
    //public async Task<IActionResult> UpdateAsync(Guid id, UpdateBankModel updateBankModel)
    //{
    //    return Ok(ApiResult<UpdateBankResponseModel>.Success(
    //        await _bankService.UpdateAsync(id, updateBankModel)));
    //}

    //[HttpDelete("{id:guid}")]
    //public async Task<IActionResult> DeleteAsync(Guid id)
    //{
    //    return Ok(ApiResult<BaseResponseModel>.Success(await _bankService.DeleteAsync(id)));
    //}
}
