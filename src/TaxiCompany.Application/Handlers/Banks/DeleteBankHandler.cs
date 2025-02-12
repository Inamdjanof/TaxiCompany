using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCompany.Application.Commands.Banks;
using TaxiCompany.Application.Models;
using TaxiCompany.DataAccess.Repositories;

namespace TaxiCompany.Application.Handlers.Banks
{
    public class DeleteBankHandler : IRequestHandler<DeleteBankCommand, BaseResponseModel>
    {
        private readonly IBankRepository _bankRepository;

        public DeleteBankHandler(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public async Task<BaseResponseModel> Handle(DeleteBankCommand request, CancellationToken cancellationToken)
        {
            var bank = await _bankRepository.GetFirstAsync(ti => ti.Id == request.Id);
            var result = await _bankRepository.DeleteAsync(bank);

            return new BaseResponseModel { Id = result.Id };
        }
    }


}
