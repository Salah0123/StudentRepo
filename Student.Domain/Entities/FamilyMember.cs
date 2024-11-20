using System.ComponentModel.DataAnnotations;

namespace Student.Domain.Entities
{
    public sealed class FamilyMember
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; } = default!;
        public int RelationshipId { get; set; }
        public Relationship Relationship { get; set; } = default!;

        public int? NationalityId { get; set; }
        public Nationality Nationality { get; set; } = default!;
    }
}