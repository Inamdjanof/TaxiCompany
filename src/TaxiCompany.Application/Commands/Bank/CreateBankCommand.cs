using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCompany.Application.Models.Bank;

namespace TaxiCompany.Application.Commands.Banks
{
    public class CreateBankCommand : IRequest<CreateBankResponseModel>
    {
        public CreateBankModel Bank { get; set; }
    }

}
