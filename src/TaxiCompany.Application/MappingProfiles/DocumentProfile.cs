using AutoMapper;
using TaxiCompany.Application.Models.Document;
using TaxiCompany.Core.Entities;

namespace TaxiCompany.Application.MappingProfiles;

public class DocumentProfile : Profile
{
    public DocumentProfile()
    {

        CreateMap<CreateDocumentModel, Document>();

        CreateMap<Document, DocumentResponseModel>();

    }
}
