using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxiCompany.Core.Entities;

namespace TaxiCompany.DataAccess.Persistence.Configurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasMany(tl => tl.Companies)
            .WithMany(ti => ti.Cars);

        builder.Property(tl => tl.Model)
            .HasMaxLength(15)
            .IsRequired();
    }
}
