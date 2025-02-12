using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCompany.Application.Models.Company;

namespace TaxiCompany.Application.Commands.Companys
{
    public class CreateCompanyCommand : IRequest<CreateCompanyResponseModel>
    {
        public CreateCompanyModel Company { get; set; }

        public CreateCompanyCommand(CreateCompanyModel company)
        {
            Company = company;
        }
    }


}
