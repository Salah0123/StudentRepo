using Mapster;
using Microsoft.EntityFrameworkCore;
using Student.Domain.Contracts.Students;
using Student.Domain.Interfaces;
using Student.Infrastructure.Persistence;

namespace Student.Application.Services
{
    public class StudentService(ApplicationDbContext context) : IStudentService
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<StudentResponse>> GetStudentsAsync(CancellationToken cancellationToken = default)
        {
            var students = await _context.Students
                .Include(x=>x.Nationality)
                .Include(x=>x.FamilyMembers)
                .ThenInclude(x=>x.Relationship)
                //.ThenInclude(x=>x.Nationality)
                .ToListAsync(cancellationToken);
            return students.Adapt<IEnumerable<StudentResponse>>();
        }

        public async Task<StudentResponse?> GetStudentById(int id, CancellationToken cancellationToken = default)
        {
            var student = await _context.Students
                .Include(x => x.Nationality)
                .Include(x => x.FamilyMembers)
                .ThenInclude(x => x.Relationship)
                .SingleOrDefaultAsync(x=>x.Id == id,cancellationToken);
            if (student is null)
                return null;
            return student.Adapt<StudentResponse>();
        }

        public async Task<(int?,string?)> AddAsync(StudentRequest request, CancellationToken cancellationToken = default)
        {
            var nationalityIsExists = await _context.Nationalities.AnyAsync(x=>x.Id == request.NationalityId);
            if (!nationalityIsExists)
                return (null,"invalid Nationality");
            var newStudent = request.Adapt<Domain.Entities.Student>();
            await _context.Students.AddAsync(newStudent, cancellationToken);
            await _context.SaveChangesAsync();
            return (newStudent.Id, null);
        }

        public async Task<bool> UpdateAsync(int id, StudentRequest request, CancellationToken cancellationToken = default)
        {
            var student = await _context.Students.SingleOrDefaultAsync(x=>x.Id == id,cancellationToken); 
            if (student is null) 
                return false;
            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.NationalityId = request.NationalityId;
            student.DateOfBirth = request.DateOfBirth;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateStudentNationalityAsync(int id, StudentNationalityRequest request, CancellationToken cancellationToken = default)
        {
            var student = await _context.Students.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (student is null)
                return false;
            var nationalityIsExists = await _context.Nationalities.AnyAsync(x=>x.Id == request.NationalityId,cancellationToken);
            if (!nationalityIsExists)
                return false;
            student.NationalityId= request.NationalityId;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}