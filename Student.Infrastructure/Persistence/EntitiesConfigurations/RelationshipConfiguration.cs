using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student.Domain.Entities;

namespace Student.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class RelationshipConfiguration : IEntityTypeConfiguration<Relationship>
    {
        public void Configure(EntityTypeBuilder<Relationship> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.HasData([
                new Relationship {Id = 1, Name = "Parent"},
                new Relationship {Id = 2, Name = "Sibling"},
                new Relationship {Id = 3, Name = "Spouse"},
            ]);
        }
    }
}