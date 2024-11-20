using Mapster;
using Microsoft.EntityFrameworkCore;
using Student.Domain.Contracts.Nationalities;
using Student.Domain.Interfaces;
using Student.Infrastructure.Persistence;

namespace Student.Application.Services
{
    public class NationalityService(ApplicationDbContext context) : INationalityService
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<NationalityResponse>> GetNationalities(CancellationToken cancellationToken)
        {
            var nationalities = await _context.Nationalities.ToListAsync(cancellationToken);
            return nationalities.Adapt<IEnumerable<NationalityResponse>>();
        }
    }
}
