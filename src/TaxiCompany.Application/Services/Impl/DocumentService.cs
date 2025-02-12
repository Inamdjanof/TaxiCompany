using AutoMapper;
using TaxiCompany.Application.Models;
using TaxiCompany.Application.Models.Document;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Repositories;

namespace TaxiCompany.Application.Services.Impl;

public class DocumentService : IDocumentService
{
    private readonly IMapper _mapper;
    private readonly IDocumentRepository _documentRepository;
    private readonly IPersonRepository _personRepository;

    public DocumentService(IMapper mapper,
        IDocumentRepository documentRepository,
        IPersonRepository personRepository)
    {
        _mapper = mapper;
        _documentRepository = documentRepository;
        _personRepository = personRepository;
    }

    public async Task<IEnumerable<DocumentResponseModel>> GetAllByPersonId(Guid id)
    {
        var documents = _documentRepository.GetAllAsync(cti => cti.Person.Id == id);

        return _mapper.Map<IEnumerable<DocumentResponseModel>>(documents);
    }

    public async Task<CreateDocumentResponseModel> CreateAsync(CreateDocumentModel createDocumentModel)
    {
        var person = await _personRepository.GetFirstAsync(cti => cti.Id == createDocumentModel.PersonId);

        var document = _mapper.Map<Document>(createDocumentModel);
        document.Person = person;

        return new CreateDocumentResponseModel()
        {
            Id = (await _documentRepository.AddAsync(document)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var document = await _documentRepository.GetFirstAsync(cti => cti.Id == id);

        return new BaseResponseModel()
        {
            Id = (await _documentRepository.DeleteAsync(document)).Id
        };
    }
}
