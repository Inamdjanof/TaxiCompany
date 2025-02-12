using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCompany.Application.Commands.Companys;
using TaxiCompany.Application.Models.Company;
using TaxiCompany.DataAccess.Repositories;

namespace TaxiCompany.Application.Handlers.Companies
{
    public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand, UpdateCompanyResponseModel>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public UpdateCompanyHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCompanyResponseModel> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetFirstAsync(cti => cti.Id == request.Id);
            _mapper.Map(request.Company, company);

            return new UpdateCompanyResponseModel()
            {
                Id = (await _companyRepository.UpdateAsync(company)).Id
            };
        }


    }
}
