using N_Tier.DataAccess.Repositories.Impl;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Persistence;

namespace TaxiCompany.DataAccess.Repositories.Impl;

public class PersonRepository : BaseRepository<Person>, IPersonRepository
{
    public PersonRepository(DatabaseContext context) : base(context) { }
}
