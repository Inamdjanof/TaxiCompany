using AutoMapper;
using TaxiCompany.Application.Models.Bank;
using TaxiCompany.Core.Entities;

namespace TaxiCompany.Application.MappingProfiles;

public class BankProfile : Profile
{
    public BankProfile()
    {

        CreateMap<CreateBankModel, Bank>();

        CreateMap<Bank, BankResponseModel>();

    }
}
