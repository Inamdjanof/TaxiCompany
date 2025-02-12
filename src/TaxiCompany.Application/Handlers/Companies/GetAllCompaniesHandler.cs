using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCompany.Application.Models.Company;
using TaxiCompany.Application.Queries.Company;
using TaxiCompany.DataAccess.Repositories;

namespace TaxiCompany.Application.Handlers.Companies
{
    public class GetAllCompaniesHandler : IRequestHandler<GetAllCompaniesQuery, IEnumerable<CompanyResponseModel>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetAllCompaniesHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompanyResponseModel>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies = _companyRepository.GetAllAsEnumurable();
            return _mapper.Map<IEnumerable<CompanyResponseModel>>(companies);
        }
    }


}
