using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCompany.Application.Models.Company;

namespace TaxiCompany.Application.Commands.Companys
{
    public class UpdateCompanyCommand : IRequest<UpdateCompanyResponseModel>
    {
        public Guid Id { get; set; }
        public UpdateCompanyModel Company { get; set; }

        public UpdateCompanyCommand(Guid id, UpdateCompanyModel company)
        {
            Id = id;
            Company = company;
        }
    }
    
}
