using Microsoft.AspNetCore.Mvc;
using TaxiCompany.Application.Models.Company;
using TaxiCompany.Application.Models;
using TaxiCompany.Application.Services;
using MediatR;
using TaxiCompany.Application.Commands.Company;
using TaxiCompany.Application.Commands.Companys;
using TaxiCompany.Application.Queries.Company;

namespace TaxiCompany.API.Controllers;

public class CompaniesController : ApiController
{


    private readonly IMediator _mediator;

    public CompaniesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCompanies()
    {
        var result = await _mediator.Send(new GetAllCompaniesQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyModel model)
    {
        var result = await _mediator.Send(new CreateCompanyCommand(model));
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] UpdateCompanyModel model)
    {
        var result = await _mediator.Send(new UpdateCompanyCommand(id, model));
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompany(Guid id)
    {
        var result = await _mediator.Send(new DeleteCompanyCommand(id));
        return Ok(result);
    }










    // private readonly ICompanyService _companyService;

    //public CompaniesController(ICompanyService companyService)
    //{
    //    _companyService = companyService;
    //}
    //[HttpGet]
    //public async Task<IActionResult> GetAllBanksAsync()
    //{
    //    return Ok(ApiResult<IEnumerable<CompanyResponseModel>>.Success(
    //        await _companyService.GetAll()));
    //}

    //[HttpPost]
    ////[AllowAnonymous]
    //public async Task<IActionResult> CreateAsync(CreateCompanyModel createCompanyModel)
    //{
    //    return Ok(ApiResult<CreateCompanyResponseModel>.Success(
    //        await _companyService.CreateAsync(createCompanyModel)));
    //}

    //[HttpPut("{id:guid}")]
    //public async Task<IActionResult> UpdateAsync(Guid id, UpdateCompanyModel updateCompanyModel)
    //{
    //    return Ok(ApiResult<UpdateCompanyResponseModel>.Success(
    //        await _companyService.UpdateAsync(id, updateCompanyModel)));
    //}

    //[HttpDelete("{id:guid}")]
    //public async Task<IActionResult> DeleteAsync(Guid id)
    //{
    //    return Ok(ApiResult<BaseResponseModel>.Success(await _companyService.DeleteAsync(id)));
    //}

}
