using Student.Domain.Contracts.Families;
using Student.Domain.Contracts.Students;

namespace Student.Domain.Interfaces
{
    public interface IFamilyService
    {
        Task<IEnumerable<FamilyResponse>?> GetStudentFamilyAsync(int id,CancellationToken cancellationToken = default);
        Task<string?> AddFamilyMemeberAsync(int id, FamilyRequest request, CancellationToken cancellationToken = default);
        Task<string?> UpdateFamilyMemeberAsync(int id, FamilyRequest request, CancellationToken cancellationToken = default);
        Task<bool> DeleteFamilyMemeberAsync(int id, int familyMemberId, CancellationToken cancellationToken = default);
    }
}