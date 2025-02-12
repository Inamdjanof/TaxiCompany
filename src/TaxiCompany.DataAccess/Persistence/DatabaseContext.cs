using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;
using TaxiCompany.Core.Common;
using TaxiCompany.Shared.Services;
using TaxiCompany.DataAccess.Identity;
using TaxiCompany.Core.Entities;
using System.Text.RegularExpressions;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Http;
using TaxiCompany.DataAccess.Authentication;

namespace TaxiCompany.DataAccess.Persistence;

public class DatabaseContext : DbContext
{
    private readonly IClaimService _claimService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public DatabaseContext(DbContextOptions options, IClaimService claimService, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        _claimService = claimService;
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        _httpContextAccessor = httpContextAccessor;
    }


    public DbSet<Bank> Banks { get; set; }

    public DbSet<Car> Cars { get; set; }

    public DbSet<Card> Cards { get; set; }

    public DbSet<CarOwner> CarsOwners { get; set; }

    public DbSet<Client> Clients { get; set; }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Impressions> Impressions { get; set; }

    public DbSet<Insurance> Insurances { get; set; }

    public DbSet<Person> People { get; set; }

    public DbSet<Document> Documents { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<Trip> Trips { get; set; }

    public DbSet<Company> Companies { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<LogEntry> LogEntries { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in ChangeTracker.Entries<IAuditedEntity>())
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = _httpContextAccessor.HttpContext?.User?.FindFirst(CustomClaimNames.Id)?.Value!;
                    entry.Entity.CreatedOn = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedBy = _claimService.GetUserId();
                    entry.Entity.UpdatedOn = DateTime.Now;
                    break;
            }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
