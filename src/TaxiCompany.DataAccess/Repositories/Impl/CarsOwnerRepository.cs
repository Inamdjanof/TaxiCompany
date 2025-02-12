using N_Tier.DataAccess.Repositories.Impl;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Persistence;

namespace TaxiCompany.DataAccess.Repositories.Impl;

public class CarsOwnerRepository : BaseRepository<CarOwner>, ICarsOwnerRepository
{
    public CarsOwnerRepository(DatabaseContext context) : base(context) { }
}
