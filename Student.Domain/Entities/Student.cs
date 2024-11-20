using System.ComponentModel.DataAnnotations;

namespace Student.Domain.Entities
{
    public sealed class Student
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public int NationalityId { get; set; }
        public Nationality Nationality { get; set; } = default!;

        public ICollection<FamilyMember> FamilyMembers { get; set; } = [];
    }
}