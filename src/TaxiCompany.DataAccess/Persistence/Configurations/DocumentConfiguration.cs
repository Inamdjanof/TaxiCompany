using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TaxiCompany.Core.Entities;

namespace TaxiCompany.DataAccess.Persistence.Configurations;

public class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.HasOne(tl => tl.Person);

        builder.Property(tl => tl.Series)
            .HasMaxLength(2)
            .IsRequired();

        builder.Property(tl => tl.Num)
            .HasMaxLength(7);

        builder.Property(tl => tl.Pnfl)
            .HasMaxLength(14);
    }
}
