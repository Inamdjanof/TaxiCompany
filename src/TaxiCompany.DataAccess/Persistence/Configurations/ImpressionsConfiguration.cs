using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TaxiCompany.Core.Entities;

namespace TaxiCompany.DataAccess.Persistence.Configurations;

public class ImpressionsConfiguration : IEntityTypeConfiguration<Impressions>
{
    public void Configure(EntityTypeBuilder<Impressions> builder)
    {
        builder.HasOne(tl => tl.Car);

        builder.Property(tl => tl.Stars)
            .HasMaxLength(5);
    }
}
