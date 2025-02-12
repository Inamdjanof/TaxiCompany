using N_Tier.DataAccess.Repositories.Impl;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Persistence;

namespace TaxiCompany.DataAccess.Repositories.Impl;

public class ClientRepository : BaseRepository<Client>, IClientRepository
{
    public ClientRepository(DatabaseContext context) : base(context) { }
}
