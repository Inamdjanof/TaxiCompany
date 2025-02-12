using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCompany.Application.Models;

namespace TaxiCompany.Application.Commands.Banks
{
    public class DeleteBankCommand : IRequest<BaseResponseModel>
    {
        public Guid Id { get; set; }
    }
    
    
}
