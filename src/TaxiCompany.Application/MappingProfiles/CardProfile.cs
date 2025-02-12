using AutoMapper;
using TaxiCompany.Application.Models.Bank;
using TaxiCompany.Application.Models.Card;
using TaxiCompany.Core.Entities;

namespace TaxiCompany.Application.MappingProfiles;

public class CardProfile : Profile
{
    public CardProfile()
    {

        CreateMap<CreateCardModel, Card>();

        CreateMap<Card, CardResponseModel>();

    }
}
