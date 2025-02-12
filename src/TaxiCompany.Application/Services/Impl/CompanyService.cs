using AutoMapper;
using TaxiCompany.Application.Models;
using TaxiCompany.Application.Models.Company;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Repositories;

namespace TaxiCompany.Application.Services.Impl;

public class CompanyService : ICompanyService
{
    private readonly IMapper _mapper;
    private readonly ICompanyRepository _companyRepository;
    private readonly IBankRepository _bankRepository;
    private readonly ICarRepository _carRepository;

    public CompanyService(IMapper mapper,
        ICompanyRepository companyRepository,
        IBankRepository bankRepository,
        ICarRepository carRepository)
    {
        _mapper = mapper;
        _companyRepository = companyRepository;
        _bankRepository = bankRepository;
        _carRepository = carRepository;
    }

    public async Task<IEnumerable<CompanyResponseModel>> GetAll()
    {
        var companies = _companyRepository.GetAllAsEnumurable();
        
        return _mapper.Map<IEnumerable<CompanyResponseModel>>(companies);
    }

    public async Task<CreateCompanyResponseModel> CreateAsync(CreateCompanyModel createCompanyModel)
    {
        var bank = await _bankRepository.GetFirstAsync(cti => cti.Id == createCompanyModel.BankId);

        var company = _mapper.Map<Company>(createCompanyModel);
        company.Bank = bank;


        return new CreateCompanyResponseModel()
        {
            Id = (await _companyRepository.AddAsync(company)).Id
        };
    }

    public async Task<UpdateCompanyResponseModel> UpdateAsync(Guid id, UpdateCompanyModel updateCompanyModel)
    {
        var company = await _companyRepository.GetFirstAsync(cti => cti.Id == id);
        _mapper.Map(company, updateCompanyModel);

        return new UpdateCompanyResponseModel()
        {
            Id = (await _companyRepository.UpdateAsync(company)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var company = await _companyRepository.GetFirstAsync(cti => cti.Id == id);

        return new BaseResponseModel()
        {
            Id = (await _companyRepository.DeleteAsync(company)).Id
        };
    }
}
