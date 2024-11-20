using Microsoft.AspNetCore.Mvc;
using Student.Domain.Contracts.Families;
using Student.Domain.Contracts.Students;
using Student.Domain.Interfaces;

namespace Student.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController(IStudentService studentService) : ControllerBase
    {
        private readonly IStudentService _studentService = studentService;
        [HttpGet("")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await _studentService.GetStudentsAsync(cancellationToken));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentById(id, cancellationToken);
            if (student is null)
                return NotFound();
            return Ok(student);
        }
        [HttpPost("")]
        public async Task<IActionResult> Add(StudentRequest request, CancellationToken cancellationToken)
        {
            var (id,error) = await _studentService.AddAsync(request, cancellationToken);
            if(error is not null)
                return BadRequest(error);
            return RedirectToAction(nameof(GetById),new {id}); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,StudentRequest request, CancellationToken cancellationToken)
        {
            var isUpdated = await _studentService.UpdateAsync(id, request, cancellationToken);
            if (!isUpdated)
                return NotFound();
            return RedirectToAction(nameof(GetById), new { id });
        }

        [HttpPut("nationality/{id}")]
        public async Task<IActionResult> UpdateStudentNationality(int id, StudentNationalityRequest request, CancellationToken cancellationToken)
        {
            var isUpdated = await _studentService.UpdateStudentNationalityAsync(id, request, cancellationToken);
            if (!isUpdated)
                return NotFound();
            return RedirectToAction(nameof(GetById), new { id });
        }
    }
}