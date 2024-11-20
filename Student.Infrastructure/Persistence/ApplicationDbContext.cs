using Microsoft.EntityFrameworkCore;
using Student.Domain.Entities;
using System.Reflection;

namespace Student.Infrastructure.Persistence
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public required DbSet<Domain.Entities.Student> Students { get; set; }
        public required DbSet<Relationship> Relationships { get; set; }
        public required DbSet<Nationality> Nationalities { get; set; }
        public required DbSet<FamilyMember> FamilyMembers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FamilyMember>()
            .HasOne(fm => fm.Nationality)
            .WithMany(n => n.FamilyMembers)
            .HasForeignKey(fm => fm.NationalityId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}