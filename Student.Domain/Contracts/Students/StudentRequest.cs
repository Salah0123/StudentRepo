using System.ComponentModel.DataAnnotations;

namespace Student.Domain.Contracts.Students
{
    public class StudentRequest
    {
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public int NationalityId { get; set; }
    }
}
