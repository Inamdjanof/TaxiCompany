using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCompany.Application.Commands.Company;
using TaxiCompany.Application.Models;
using TaxiCompany.DataAccess.Repositories;

namespace TaxiCompany.Application.Handlers.Companies
{
    public class DeleteCompanyHandler : IRequestHandler<DeleteCompanyCommand, BaseResponseModel>
    {
        private readonly ICompanyRepository _companyRepository;

        public DeleteCompanyHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<BaseResponseModel> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetFirstAsync(cti => cti.Id == request.Id);

            return new BaseResponseModel()
            {
                Id = (await _companyRepository.DeleteAsync(company)).Id
            };
        }
    }

  }
