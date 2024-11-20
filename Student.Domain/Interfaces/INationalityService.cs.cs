using Student.Domain.Contracts.Nationalities;

namespace Student.Domain.Interfaces
{
    public interface INationalityService
    {
        Task<IEnumerable<NationalityResponse>> GetNationalities(CancellationToken cancellationToken);
    }
}
