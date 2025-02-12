using N_Tier.DataAccess.Repositories.Impl;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Persistence;

namespace TaxiCompany.DataAccess.Repositories.Impl;

public class TripRepository : BaseRepository<Trip>, ITripRepository
{
    public TripRepository(DatabaseContext context) : base(context) { }
}
