using N_Tier.DataAccess.Repositories.Impl;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Persistence;

namespace TaxiCompany.DataAccess.Repositories.Impl;

public class DocumentRepository : BaseRepository<Document>, IDocumentRepository
{
    public DocumentRepository(DatabaseContext context) : base(context) { }
}
