using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCompany.Application.Models.Bank;

namespace TaxiCompany.Application.Commands.Banks
{
    public class UpdateBankCommand : IRequest<UpdateBankResponseModel>
    {
        public Guid Id { get; set; }
        public UpdateBankModel Bank { get; set; }
    }

}
