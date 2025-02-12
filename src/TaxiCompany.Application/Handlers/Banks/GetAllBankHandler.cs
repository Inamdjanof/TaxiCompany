using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCompany.Application.Models.Bank;
using TaxiCompany.Application.Queries.Banks;
using TaxiCompany.DataAccess.Repositories;

namespace TaxiCompany.Application.Handlers.Banks
{
    public class GetAllBankHandler : IRequestHandler<GetAllBanksQuery, IEnumerable<BankResponseModel>>
    {
        private readonly IBankRepository _bankRepository;
        private readonly IMapper _mapper;

        public GetAllBankHandler(IBankRepository bankRepository, IMapper mapper)
        {
            _bankRepository = bankRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BankResponseModel>> Handle(GetAllBanksQuery request, CancellationToken cancellationToken)
        {
            var banks = _bankRepository.GetAllAsEnumurable();
            return _mapper.Map<IEnumerable<BankResponseModel>>(banks);
        }


    }
}
