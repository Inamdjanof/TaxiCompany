using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCompany.Application.Commands.Companys;
using TaxiCompany.Application.Models.Company;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Repositories;

namespace TaxiCompany.Application.Handlers.Companies
{
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, CreateCompanyResponseModel>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IBankRepository _bankRepository;
        private readonly IMapper _mapper;

        public CreateCompanyHandler(ICompanyRepository companyRepository, IBankRepository bankRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _bankRepository = bankRepository;
            _mapper = mapper;
        }

        public async Task<CreateCompanyResponseModel> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var bank = await _bankRepository.GetFirstAsync(cti => cti.Id == request.Company.BankId);

            var company = _mapper.Map<Company>(request.Company);
            company.Bank = bank;

            return new CreateCompanyResponseModel()
            {
                Id = (await _companyRepository.AddAsync(company)).Id
            };
        }

    }

    }
