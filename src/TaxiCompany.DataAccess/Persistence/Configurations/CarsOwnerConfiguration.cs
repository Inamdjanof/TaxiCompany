using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TaxiCompany.Core.Entities;

namespace TaxiCompany.DataAccess.Persistence.Configurations;

public class CarOwnerConfiguration : IEntityTypeConfiguration<CarOwner>
{
    public void Configure(EntityTypeBuilder<CarOwner> builder)
    {
        builder.HasOne(tl => tl.Person);


        builder.Property(tl => tl.Priprity)
            .HasMaxLength(100);

        builder.Property(tl => tl.Rating)
            .HasMaxLength(5);

    }
}
