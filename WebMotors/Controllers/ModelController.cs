using Microsoft.AspNetCore.Mvc;
using WebMotors.Repositories;

namespace WebMotors.Controllers
{
    [Route("api/[controller]")]
    public class ModelController : ControllerBase
    {
        [HttpGet("{makeId}")]
        public async Task<IActionResult> GetModels(
            [FromRoute] int makeId,
            [FromServices] IModelRepository repository)
        {
            if (makeId == null)
                return StatusCode(500, "Id nulo");

            var models = await repository.GetModels(makeId);
            return Ok(models);
        }
    }
}
