using N_Tier.DataAccess.Repositories.Impl;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Persistence;

namespace TaxiCompany.DataAccess.Repositories.Impl;

public class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    public RoleRepository(DatabaseContext context) : base(context) { }
}
