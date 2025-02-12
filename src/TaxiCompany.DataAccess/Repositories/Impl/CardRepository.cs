using N_Tier.DataAccess.Repositories.Impl;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Persistence;

namespace TaxiCompany.DataAccess.Repositories.Impl;

public class CardRepository : BaseRepository<Card>, ICardRepository
{
    public CardRepository(DatabaseContext context) : base(context) { }
}
