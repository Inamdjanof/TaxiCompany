using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxiCompany.Core.Entities;

namespace TaxiCompany.DataAccess.Persistence.Configurations;

public class CardConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.HasOne(tl => tl.Bank);

        builder.HasOne(tl => tl.Person);

        builder.Property(tl => tl.Num)
            .HasMaxLength(16)
            .IsRequired();

        builder.Property(tl => tl.Term)
            .HasMaxLength(5)
            .IsRequired();

    }
}
