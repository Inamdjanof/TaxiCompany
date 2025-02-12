using AutoMapper;
using Moq;
using System.Linq.Expressions;
using TaxiCompany.Application.Models;
using TaxiCompany.Application.Models.Bank;
using TaxiCompany.Application.Models.Company;
using TaxiCompany.Application.Services;
using TaxiCompany.Application.Services.Impl;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Repositories;

namespace TestProject
{

    public class CompanyServiceTests
    {
        private readonly Mock<ICompanyRepository> _companyRepositoryMock;
        private readonly Mock<IBankRepository> _bankRepositoryMock;
        private readonly Mock<ICarRepository> _carRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly CompanyService _companyService;

        public CompanyServiceTests()
        {
            _companyRepositoryMock = new Mock<ICompanyRepository>();
            _bankRepositoryMock = new Mock<IBankRepository>();
            _carRepositoryMock = new Mock<ICarRepository>();
            _mapperMock = new Mock<IMapper>();

            _companyService = new CompanyService(
                _mapperMock.Object,
                _companyRepositoryMock.Object,
                _bankRepositoryMock.Object,
                _carRepositoryMock.Object
            );
        }

        
        [Fact]
        public async Task GetAll_ShouldReturnListOfCompanies()
        {
            
            var companies = new List<Company>
        {
            new Company { Id = Guid.NewGuid(), Name = "Company A" },
            new Company { Id = Guid.NewGuid(), Name = "Company B" }
        };

            _companyRepositoryMock
                .Setup(repo => repo.GetAllAsEnumurable())
                .Returns(companies);

            _mapperMock
                .Setup(mapper => mapper.Map<IEnumerable<CompanyResponseModel>>(companies))
                .Returns(companies.Select(c => new CompanyResponseModel { Id = c.Id, Name = c.Name }));

           
            var result = await _companyService.GetAll();

            
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

      
        [Fact]
        public async Task CreateAsync_ShouldReturnCreatedCompanyId()
        {
            var bankId = Guid.NewGuid();
            var companyId = Guid.NewGuid();
            var createModel = new CreateCompanyModel { Name = "New Company", BankId = bankId };
            var bank = new Bank { Id = bankId, Name = "Test Bank" };
            var company = new Company { Id = companyId, Name = "New Company", Bank = bank };

            _bankRepositoryMock
                .Setup(repo => repo.GetFirstAsync(It.IsAny<Expression<Func<Bank, bool>>>()))
                .ReturnsAsync(bank);

            _mapperMock
                .Setup(mapper => mapper.Map<Company>(createModel))
                .Returns(company);

            _companyRepositoryMock
                .Setup(repo => repo.AddAsync(company))
                .ReturnsAsync(company);
            
            var result = await _companyService.CreateAsync(createModel);

           
            Assert.NotNull(result);
            Assert.Equal(companyId, result.Id);
        }


        [Fact]
        public async Task UpdateAsync_ShouldReturnUpdatedCompanyId()
        {
         
            var companyId = Guid.NewGuid();
            var existingCompany = new Company { Id = companyId, Name = "Old Name" };
            var updateModel = new UpdateCompanyModel { Name = "Updated Name" };

            _companyRepositoryMock
                .Setup(repo => repo.GetFirstAsync(It.IsAny<Expression<Func<Company, bool>>>()))
                .ReturnsAsync(existingCompany);

            _mapperMock
                .Setup(mapper => mapper.Map(updateModel, existingCompany))
                .Callback<UpdateCompanyModel, Company>((src, dest) => dest.Name = src.Name);

            _companyRepositoryMock
                .Setup(repo => repo.UpdateAsync(existingCompany))
                .ReturnsAsync(existingCompany);

            // Act
            var result = await _companyService.UpdateAsync(companyId, updateModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(companyId, result.Id);
        }

        // ✅ DeleteAsync() testi
        [Fact]
        public async Task DeleteAsync_ShouldReturnDeletedCompanyId()
        {
            // Arrange
            var companyId = Guid.NewGuid();
            var existingCompany = new Company { Id = companyId, Name = "To Be Deleted" };

            _companyRepositoryMock
                .Setup(repo => repo.GetFirstAsync(It.IsAny<Expression<Func<Company, bool>>>()))
                .ReturnsAsync(existingCompany);

            _companyRepositoryMock
                .Setup(repo => repo.DeleteAsync(existingCompany))
                .ReturnsAsync(existingCompany);

            // Act
            var result = await _companyService.DeleteAsync(companyId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(companyId, result.Id);
        }
    }



    public class BankServiceTest
    {
        private readonly Mock<IBankRepository> _bankRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly BankService _bankService;

        public BankServiceTest()
        {
            _bankRepositoryMock = new Mock<IBankRepository>(); 
            _mapperMock = new Mock<IMapper>();

           
            _bankService = new BankService(_bankRepositoryMock.Object, _mapperMock.Object);
        }


        
        [Fact]
        public async Task GetAllAsync_ShouldReturnMappedResponse()
        {
          
            var banks = new List<Bank>
        {
            new Bank { Id = Guid.NewGuid(), Name = "Bank 1" },
            new Bank { Id = Guid.NewGuid(), Name = "Bank 2" }
        };

            var expectedResponse = new List<BankResponseModel>
        {
            new BankResponseModel { Id = banks[0].Id, Name = "Bank 1" },
            new BankResponseModel { Id = banks[1].Id, Name = "Bank 2" }
        };

            _bankRepositoryMock
                .Setup(repo => repo.GetAllAsEnumurable())
                .Returns(banks);

            _mapperMock
                .Setup(mapper => mapper.Map<IEnumerable<BankResponseModel>>(banks))
                .Returns(expectedResponse);

           
            var result = await _bankService.GetAllAsync();

          
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal(expectedResponse, result);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnUpdatedBankResponse()
        {
            
            var bankId = Guid.NewGuid();
            var existingBank = new Bank { Id = bankId, Name = "Old Bank" };
            var updateModel = new UpdateBankModel { Name = "Updated Bank" };
            var updatedBank = new Bank { Id = bankId, Name = "Updated Bank" };

            _bankRepositoryMock
                .Setup(repo => repo.GetFirstAsync(It.IsAny<Expression<Func<Bank, bool>>>()))
                .ReturnsAsync(existingBank);

            _mapperMock
                .Setup(mapper => mapper.Map(updateModel, existingBank))
                .Callback<UpdateBankModel, Bank>((src, dest) => dest.Name = src.Name);

            _bankRepositoryMock
                .Setup(repo => repo.UpdateAsync(existingBank))
                .ReturnsAsync(updatedBank);

            
            var result = await _bankService.UpdateAsync(bankId, updateModel);

           
            Assert.NotNull(result);
            Assert.Equal(bankId, result.Id);
        }







        [Fact]
        public async Task CreateAsync_ShouldReturnValidResponse()
        {
           
            var id = Guid.NewGuid();
            var createModel = new CreateBankModel { };
            var bank = new Bank { Id = id };
            var responseModel = new CreateBankResponseModel { Id = id }; 

            _mapperMock
                .Setup(m => m.Map<Bank>(It.IsAny<CreateBankModel>()))
                .Returns(bank);

            _bankRepositoryMock
                .Setup(repo => repo.AddAsync(It.IsAny<Bank>()))
                .ReturnsAsync(bank);

            // Act
            var result = await _bankService.CreateAsync(createModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnValidResponse()
        {
            // Arrange
            var id = Guid.NewGuid();
            var bank = new Bank { Id = id };
            var responseModel = new BaseResponseModel { Id = id };

            _bankRepositoryMock
                .Setup(repo => repo.GetFirstAsync(It.IsAny<Expression<Func<Bank, bool>>>()))
                .ReturnsAsync(bank);

            _bankRepositoryMock
                .Setup(repo => repo.DeleteAsync(It.IsAny<Bank>()))
                .ReturnsAsync(bank);

            // Act
            var result = await _bankService.DeleteAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }



    }
}