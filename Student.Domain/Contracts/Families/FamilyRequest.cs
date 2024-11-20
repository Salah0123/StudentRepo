using System.ComponentModel.DataAnnotations;

namespace Student.Domain.Contracts.Families
{
    public class FamilyRequest
    {
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public int? FamilyId { get; set; }
        public int RelationshipId { get; set; }
    }
}