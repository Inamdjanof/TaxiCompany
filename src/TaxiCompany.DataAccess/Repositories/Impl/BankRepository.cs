using N_Tier.DataAccess.Repositories.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Persistence;

namespace TaxiCompany.DataAccess.Repositories.Impl;

public class BankRepository : BaseRepository<Bank>, IBankRepository
{
    public BankRepository(DatabaseContext context) : base(context) { }
}
