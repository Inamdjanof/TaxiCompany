using N_Tier.DataAccess.Repositories.Impl;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Persistence;

namespace TaxiCompany.DataAccess.Repositories.Impl;

public class InsuranceRepository : BaseRepository<Insurance>, IInsuranceRepository
{
    public InsuranceRepository(DatabaseContext context) : base(context) { }
}
