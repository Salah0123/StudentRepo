using Microsoft.AspNetCore.Mvc;
using Student.Domain.Contracts.Families;
using Student.Domain.Interfaces;

namespace Student.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyMembersController(IFamilyService familyService) : ControllerBase
    {
        private readonly IFamilyService _familyService = familyService;
        [HttpGet("")]
        public async Task<IActionResult> GetStudentFamilyAsync(int id, CancellationToken cancellationToken)
        {
            var family = await _familyService.GetStudentFamilyAsync(id, cancellationToken);
            return family is null? BadRequest("student not found"): Ok(family);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> AddFamilyMember(int id, FamilyRequest request, CancellationToken cancellationToken)
        {
            var error = await _familyService.AddFamilyMemeberAsync(id, request, cancellationToken);
            if (error is not null)
                return BadRequest(error);
            return RedirectToAction("GetById", "Students", new { id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFamilyMember(int id, FamilyRequest request, CancellationToken cancellationToken)
        {
            var error = await _familyService.UpdateFamilyMemeberAsync(id, request, cancellationToken);
            if (error is not null)
                return BadRequest(error);
            return Ok();//RedirectToAction("GetById", "Students", new { id });
        }

        [HttpDelete("{id}/{familyId}")]
        public async Task<IActionResult> DeleteFamilyMember(int id, int familyId, CancellationToken cancellationToken)
        {
            var isDeleted = await _familyService.DeleteFamilyMemeberAsync(id, familyId, cancellationToken);
            return isDeleted? Ok() : BadRequest("invalid student / family member");
        }
    }
}