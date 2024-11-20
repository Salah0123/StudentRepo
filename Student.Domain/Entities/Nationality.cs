namespace Student.Domain.Entities
{
    public sealed class Nationality
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Student> Students { get; set; } = [];
        public ICollection<FamilyMember> FamilyMembers { get; set; } = [];
    }
}