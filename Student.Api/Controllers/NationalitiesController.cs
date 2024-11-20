using Microsoft.AspNetCore.Mvc;
using Student.Domain.Interfaces;

namespace Student.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalitiesController(INationalityService nationalityService) : ControllerBase
    {
        private readonly INationalityService _nationalityService = nationalityService;
        [HttpGet("")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken) =>
            Ok(await _nationalityService.GetNationalities(cancellationToken));
    }
}
