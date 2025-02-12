using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TaxiCompany.Core.Entities;

namespace TaxiCompany.DataAccess.Persistence.Configurations;

public class TripConfiguration : IEntityTypeConfiguration<Trip>
{
    public void Configure(EntityTypeBuilder<Trip> builder)
    {

        builder.HasOne(tl => tl.Client);

        builder.HasOne(tl => tl.Car);

    }
}
