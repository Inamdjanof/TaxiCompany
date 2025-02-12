using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCompany.Application.Commands.Banks;
using TaxiCompany.Application.Models.Bank;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Repositories;

namespace TaxiCompany.Application.Handlers.Banks
{
    public class CreateBankHandler : IRequestHandler<CreateBankCommand, CreateBankResponseModel>
    {
        private readonly IBankRepository _bankRepository;
        private readonly IMapper _mapper;

        public CreateBankHandler(IBankRepository bankRepository, IMapper mapper)
        {
            _bankRepository = bankRepository;
            _mapper = mapper;
        }

        public async Task<CreateBankResponseModel> Handle(CreateBankCommand request, CancellationToken cancellationToken)
        {
            var bank = _mapper.Map<Bank>(request.Bank);
            var result = await _bankRepository.AddAsync(bank);

            return new CreateBankResponseModel { Id = result.Id };
        }
    }


}
