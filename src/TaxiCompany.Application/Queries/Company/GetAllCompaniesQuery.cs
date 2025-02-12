using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCompany.Application.Models.Company;

namespace TaxiCompany.Application.Queries.Company
{
    public class GetAllCompaniesQuery : IRequest<IEnumerable<CompanyResponseModel>> { }
}
    
    
