using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCompany.Application.Commands.Banks;
using TaxiCompany.Application.Models.Bank;
using TaxiCompany.DataAccess.Repositories;

namespace TaxiCompany.Application.Handlers.Banks
{
    public class UpdateBankHandler : IRequestHandler<UpdateBankCommand, UpdateBankResponseModel>
    {
        private readonly IBankRepository _bankRepository;
        private readonly IMapper _mapper;

        public UpdateBankHandler(IBankRepository bankRepository, IMapper mapper)
        {
            _bankRepository = bankRepository;
            _mapper = mapper;
        }

        public async Task<UpdateBankResponseModel> Handle(UpdateBankCommand request, CancellationToken cancellationToken)
        {
            var bank = await _bankRepository.GetFirstAsync(ti => ti.Id == request.Id);
            _mapper.Map(request.Bank, bank);
            var result = await _bankRepository.UpdateAsync(bank);

            return new UpdateBankResponseModel { Id = result.Id };
        }
    }


}
