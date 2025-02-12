using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaxiCompany.DataAccess.Identity;
using TaxiCompany.DataAccess.Persistence;
using TaxiCompany.DataAccess.Repositories;
using TaxiCompany.DataAccess.Repositories.Impl;

namespace TaxiCompany.DataAccess;

public static class DataAccessDependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);

        //services.AddIdentity();

        services.AddRepositories();

        return services;
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBankRepository, BankRepository>();
        services.AddScoped<ICardRepository, CardRepository>();
        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<ICarsOwnerRepository, CarsOwnerRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<IDocumentRepository, DocumentRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IImpressionsRepository, ImpressionsRepository>();
        services.AddScoped<IInsuranceRepository, InsuranceRepository>();
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<ITripRepository, TripRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }

    private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var databaseConfig = configuration.GetSection("Database").Get<DatabaseConfiguration>();

        services.AddDbContext<DatabaseContext>(options =>
            options.UseNpgsql(databaseConfig.ConnectionString,
                opt => opt.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName)));
    }

    //private static void AddIdentity(this IServiceCollection services)
    //{
    //    services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    //        .AddEntityFrameworkStores<DatabaseContext>();

    //    services.Configure<IdentityOptions>(options =>
    //    {
    //        options.Password.RequireDigit = true;
    //        options.Password.RequireLowercase = true;
    //        options.Password.RequireNonAlphanumeric = true;
    //        options.Password.RequireUppercase = true;
    //        options.Password.RequiredLength = 6;
    //        options.Password.RequiredUniqueChars = 1;

    //        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    //        options.Lockout.MaxFailedAccessAttempts = 5;
    //        options.Lockout.AllowedForNewUsers = true;

    //        options.User.AllowedUserNameCharacters =
    //            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    //        options.User.RequireUniqueEmail = true;
    //    });
    //}
}

public class DatabaseConfiguration
{
  public bool UseInMemoryDatabase { get; set; }

  public string ConnectionString { get; set; }
}
