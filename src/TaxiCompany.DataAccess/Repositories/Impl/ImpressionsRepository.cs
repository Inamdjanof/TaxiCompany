using N_Tier.DataAccess.Repositories.Impl;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Persistence;

namespace TaxiCompany.DataAccess.Repositories.Impl;

public class ImpressionsRepository : BaseRepository<Impressions>, IImpressionsRepository
{
    public ImpressionsRepository(DatabaseContext context) : base(context) { }
}
