using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCompany.Application.Models.Bank;

namespace TaxiCompany.Application.Queries.Banks
{
    public class GetAllBanksQuery : IRequest<IEnumerable<BankResponseModel>> { }

}
