using N_Tier.DataAccess.Repositories.Impl;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Persistence;

namespace TaxiCompany.DataAccess.Repositories.Impl;

public class CarRepository : BaseRepository<Car>, ICarRepository
{
    public CarRepository(DatabaseContext context) : base(context) { }
}
