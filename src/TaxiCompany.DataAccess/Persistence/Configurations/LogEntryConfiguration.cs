using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCompany.Core.Entities;

namespace TaxiCompany.DataAccess.Persistence.Configurations
{
    public class LogEntryConfiguration : IEntityTypeConfiguration<LogEntry>
    {
        public void Configure(EntityTypeBuilder<LogEntry> builder)
        {
            builder.Property(le => le.Request)
                .IsRequired();

            builder.Property(le => le.Response)
                .IsRequired();

            builder.Property(le => le.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(le => le.CreatedBy)
                .IsRequired();

            builder.Property(le => le.CreatedOn)
                .IsRequired();

            builder.Property(le => le.UpdatedBy)
                .IsRequired(false);

            builder.Property(le => le.UpdatedOn)
                .IsRequired(false);
        }


    }
}
