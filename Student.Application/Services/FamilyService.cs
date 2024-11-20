using Azure.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Student.Domain.Contracts.Families;
using Student.Domain.Contracts.Students;
using Student.Domain.Entities;
using Student.Domain.Interfaces;
using Student.Infrastructure.Persistence;

namespace Student.Application.Services
{
    public class FamilyService(ApplicationDbContext context) : IFamilyService
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<IEnumerable<FamilyResponse>?> GetStudentFamilyAsync(int id, CancellationToken cancellationToken = default)
        {
            var student = await _context.Students.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (student is null)
                return null;
            var familyMembers = await _context.FamilyMembers.Include(x=>x.Relationship).Include(x=>x.Nationality).Where(x=>x.StudentId == id).ToListAsync(cancellationToken);

            return familyMembers.Adapt<IEnumerable<FamilyResponse>>();
        }

        public async Task<string?> AddFamilyMemeberAsync(int id, FamilyRequest request, CancellationToken cancellationToken = default)
        {
            var student = await _context.Students.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (student is null)
                return "student not found";
            var relationIsExists = await _context.Relationships.AnyAsync(x => x.Id == request.RelationshipId, cancellationToken);
            if (!relationIsExists)
                return "invalid relationship";
            var newStudentRelationShip = new FamilyMember
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                StudentId = student.Id,
                RelationshipId = request.RelationshipId,
            };
            await _context.FamilyMembers.AddAsync(newStudentRelationShip);
            await _context.SaveChangesAsync();
            return null;
        }

        

        public async Task<string?> UpdateFamilyMemeberAsync(int id, FamilyRequest request, CancellationToken cancellationToken = default)
        {
            var student = await _context.Students.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (student is null)
                return "student not found";
            var relationIsExists = await _context.Relationships.AnyAsync(x => x.Id == request.RelationshipId, cancellationToken);
            if (!relationIsExists)
                return "invalid relationship";

            var familyMember = await _context.FamilyMembers.SingleOrDefaultAsync(x => x.Id == request.FamilyId && x.StudentId == id, cancellationToken);
            if (familyMember is null)
                return "Family member not found or student not has this family member";
            familyMember.FirstName = request.FirstName;
            familyMember.LastName = request.LastName;
            familyMember.DateOfBirth = request.DateOfBirth;
            familyMember.RelationshipId = request.RelationshipId;
            await _context.SaveChangesAsync(cancellationToken);
            return null;
        }

        public async Task<bool> DeleteFamilyMemeberAsync(int id, int familyMemberId, CancellationToken cancellationToken = default)
        {
            var student = await _context.Students.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (student is null)
                return false;
            var familyMember = await _context.FamilyMembers.SingleOrDefaultAsync(x => x.Id == familyMemberId && x.StudentId == id, cancellationToken);
            if (familyMember is null)
                return false;

            _context.FamilyMembers.Remove(familyMember);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
