using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCompany.Core.Entities;
using TaxiCompany.Core.Enums;

namespace TaxiCompany.DataAccess.Persistence.Configurations
{
    public  class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);

            builder
                .Property(user => user.FirstName)
                .HasMaxLength(100)
                .IsRequired(true);

            builder
                .Property(user => user.LastName)
                .HasMaxLength(100)
                .IsRequired(false);

            builder
                .Property(user => user.Email)
                .HasMaxLength(255)
                .IsRequired(true);

            builder
                .Property(user => user.PasswordHash)
                .HasMaxLength(256)
                .IsRequired(true);

            builder
                .Property(user => user.Salt)
                .HasMaxLength(100)
                .IsRequired(true);

            builder
                .Property(user => user.CreatedAt)
                .IsRequired(true);

            builder.HasData(GenerateUsers());
        }

        private List<User> GenerateUsers()
        {
            return new List<User>
        {
            new User
            {
                Id = Guid.Parse("bc56836e-0345-4f01-a883-47f39e32e079"),
                FirstName = "Akmal",
                Role = UserRole.Admin,
                Email = "inomjonov@gmail.com",
                PasswordHash = "12345678",
                Salt = Guid.NewGuid().ToString()
            }
        };
        }

    }
}
