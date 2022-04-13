using Microsoft.AspNetCore.Mvc;
using WebMotors.Repositories;

namespace WebMotors.Controllers
{
    [Route("api/[controller]")]
    public class VersionController : ControllerBase
    {
        [HttpGet("{modelId}")]
        public async Task<IActionResult> GetVersions(
            [FromRoute] int modelId,
            [FromServices] IVersionRepository repository)
        {
            var versions = await repository.GetVersions(modelId);
            return Ok(versions);
        }
    }
}
