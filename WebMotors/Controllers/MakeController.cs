using Microsoft.AspNetCore.Mvc;
using WebMotors.Repositories;

namespace WebMotors.Controllers
{
    [Route("api/[controller]")]
    public class MakeController : ControllerBase
    {
        [HttpGet()]
        public async Task<IActionResult> Get(
            [FromServices] IMakeRepository repository)
        {
            var makes = await repository.GetMake();
            return Ok(makes);
        }
    }
}
