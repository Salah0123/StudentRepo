using Student.Domain.Contracts.Families;
using Student.Domain.Contracts.Students;

namespace Student.Domain.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentResponse>> GetStudentsAsync(CancellationToken cancellationToken = default);
        Task<StudentResponse?> GetStudentById(int id, CancellationToken cancellationToken = default);
        Task<(int?, string?)> AddAsync(StudentRequest request, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(int id,StudentRequest request, CancellationToken cancellationToken = default);
        Task<bool> UpdateStudentNationalityAsync(int id, StudentNationalityRequest request, CancellationToken cancellationToken = default);
    }
}