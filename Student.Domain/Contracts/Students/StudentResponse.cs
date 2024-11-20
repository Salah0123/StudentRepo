namespace Student.Domain.Contracts.Students
{
    public class StudentResponse
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Nationality { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public IEnumerable<FamilyResponse> Familys { get; set; } = [];
    }
}
