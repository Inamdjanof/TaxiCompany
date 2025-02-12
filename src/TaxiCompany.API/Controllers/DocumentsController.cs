using Microsoft.AspNetCore.Mvc;
using TaxiCompany.Application.Models.Document;
using TaxiCompany.Application.Models;
using TaxiCompany.Application.Services;

namespace TaxiCompany.API.Controllers;

public class DocumentsController : ApiController
{
    private readonly IDocumentService _documentService;

    public DocumentsController(IDocumentService documentService)
    {
        _documentService = documentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBanksAsync(Guid id)
    {
        return Ok(ApiResult<IEnumerable<DocumentResponseModel>>.Success(
            await _documentService.GetAllByPersonId(id)));
    }

    [HttpPost]
    
    public async Task<IActionResult> CreateAsync(CreateDocumentModel createDocumentModel)
    {
        return Ok(ApiResult<CreateDocumentResponseModel>.Success(
            await _documentService.CreateAsync(createDocumentModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(await _documentService.DeleteAsync(id)));
    }
}
