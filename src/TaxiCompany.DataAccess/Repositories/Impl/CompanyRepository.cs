using N_Tier.DataAccess.Repositories.Impl;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Persistence;

namespace TaxiCompany.DataAccess.Repositories.Impl;

public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
{
    public CompanyRepository(DatabaseContext context) : base(context) { }
}
