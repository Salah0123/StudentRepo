using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student.Domain.Entities;

namespace Student.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class NationalityConfiguration : IEntityTypeConfiguration<Nationality>
    {
        public void Configure(EntityTypeBuilder<Nationality> builder)
        {
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(100);

            builder.HasData([
                new Nationality { Id = 1, Name = "Egyptian" },
                new Nationality { Id = 2, Name = "American" },
                new Nationality { Id = 3, Name = "Canadian" },
                new Nationality { Id = 4, Name = "British" },
                new Nationality { Id = 5, Name = "Australian" },
                new Nationality { Id = 6, Name = "Indian" },
                new Nationality { Id = 7, Name = "German" },
                new Nationality { Id = 8, Name = "French" },
                new Nationality { Id = 9, Name = "Spanish" },
                new Nationality { Id = 10, Name = "Italian" },
                new Nationality { Id = 11, Name = "Chinese" },
                new Nationality { Id = 12, Name = "Japanese" },
                new Nationality { Id = 13, Name = "Russian" },
                new Nationality { Id = 14, Name = "Brazilian" },
                new Nationality { Id = 15, Name = "Mexican" },
                new Nationality { Id = 16, Name = "South African" },
                new Nationality { Id = 17, Name = "Nigerian" },
                new Nationality { Id = 18, Name = "Saudi Arabian" },
                new Nationality { Id = 19, Name = "Pakistani" },
                new Nationality { Id = 20, Name = "Turkish" }
            ]);
        }
    }
}