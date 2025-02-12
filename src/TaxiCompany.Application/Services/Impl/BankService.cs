using AutoMapper;
using TaxiCompany.Application.Models;
using TaxiCompany.Application.Models.Bank;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Repositories;

namespace TaxiCompany.Application.Services.Impl;

public class BankService : IBankService
{
    private readonly IMapper _mapper;
    private readonly IBankRepository _bankRepository;

    public BankService(IBankRepository bankRepository,
        IMapper mapper)
    {
        _bankRepository = bankRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BankResponseModel>> GetAllAsync()
    {
        var banks = _bankRepository.GetAllAsEnumurable();

        return _mapper.Map<IEnumerable<BankResponseModel>>(banks);
    }


    public async Task<CreateBankResponseModel> CreateAsync(CreateBankModel createBankModel,
        CancellationToken cancellationToken = default)
    {
        var bank = _mapper.Map<Bank>(createBankModel);
        return new CreateBankResponseModel
        {
            Id = (await _bankRepository.AddAsync(bank)).Id
        };
    }

    public async Task<UpdateBankResponseModel> UpdateAsync(Guid id, UpdateBankModel updateBankModel,
        CancellationToken cancellationToken = default)
    {
        var bank = await _bankRepository.GetFirstAsync(ti => ti.Id == id);

        _mapper.Map(updateBankModel, bank);

        return new UpdateBankResponseModel
        {
            Id = (await _bankRepository.UpdateAsync(bank)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var bank = await _bankRepository.GetFirstAsync(ti => ti.Id == id);

        return new BaseResponseModel
        {
            Id = (await _bankRepository.DeleteAsync(bank)).Id
        };
    }

}
