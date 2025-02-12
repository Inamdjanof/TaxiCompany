using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCompany.Application.Models;

namespace TaxiCompany.Application.Commands.Company
{
    public class DeleteCompanyCommand : IRequest<BaseResponseModel>
    {
        public Guid Id { get; set; }

        public DeleteCompanyCommand(Guid id)
        {
            Id = id;
        }
    }


}
