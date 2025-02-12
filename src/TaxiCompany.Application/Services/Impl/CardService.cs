using AutoMapper;
using TaxiCompany.Application.Models.Bank;
using TaxiCompany.Application.Models;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Repositories;
using TaxiCompany.DataAccess.Repositories.Impl;
using TaxiCompany.Application.Models.Card;
using TaxiCompany.Application.Models.Car;

namespace TaxiCompany.Application.Services.Impl;

public class CardService : ICardService
{
    private IMapper _mapper;
    private ICardRepository _cardRepository;
    private IPersonRepository _personRepository;
    private IBankRepository _bankRepository;

    public CardService(IMapper mapper,
        ICardRepository cardRepository,
        IPersonRepository personRepository,
        IBankRepository bankRepository)
    {
        _mapper = mapper;
        _cardRepository = cardRepository;
        _personRepository = personRepository;
        _bankRepository = bankRepository;
    }

    public async Task<IEnumerable<CardResponseModel>> GetAllByPersonIdAsync(Guid id)
    {
        var cards = _cardRepository.GetFirstAsync(cti => cti.Person.Id == id);

        return _mapper.Map<IEnumerable<CardResponseModel>>(cards);
    }


    public async Task<CreateCardResponseModel> CreateAsync(CreateCardModel createCardModel,
        CancellationToken cancellationToken = default)
    {
        var person = await _personRepository.GetFirstAsync(cti => cti.Id == createCardModel.PersonId);
        var bank = await _bankRepository.GetFirstAsync(cti => cti.Id == createCardModel.BankId);

        var card = _mapper.Map<Card>(createCardModel);
        card.Bank = bank;
        card.Person = person;

        return new CreateCardResponseModel
        {
            Id = (await _cardRepository.AddAsync(card)).Id
        };
    }

    public async Task<UpdateCardResponseModel> UpdateAsync(Guid id, Models.CarsOwner.UpdateCarsOwnerModel updateCardModel,
        CancellationToken cancellationToken = default)
    {
        var card = await _cardRepository.GetFirstAsync(cti => cti.Id == id);

        _mapper.Map(updateCardModel, card);

        return new UpdateCardResponseModel
        {
            Id = (await _cardRepository.UpdateAsync(card)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var card = await _cardRepository.GetFirstAsync(ti => ti.Id == id);

        return new BaseResponseModel
        {
            Id = (await _cardRepository.DeleteAsync(card)).Id
        };
    }
}
