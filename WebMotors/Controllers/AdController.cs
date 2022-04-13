using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMotors.Data;
using WebMotors.Interfaces;
using WebMotors.Services;
using WebMotors.ViewModels;

namespace WebMotors.Controllers
{
    [ApiController]
    public class AdController : ControllerBase
    {
        [HttpGet("v1/ads")]
        public async Task<IActionResult> GetAsync(
            [FromServices] AdDataContext context)
        {
            var ads = context.Ads
                .AsNoTracking()
                .ToListAsync();
            return Ok(ads);
        }

        [HttpGet("v1/ads/{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute]int id,
            [FromServices] AdDataContext context)
        {
            var ad = context.Ads
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return Ok(ad);
        }

        [HttpPost("v1/ads")]
        public async Task<IActionResult> CreateAdAsync(
            [FromBody] AdViewModel model,
            [FromServices] IExternalAdService service,
            [FromServices] AdDataContext context)
        {
            var adService = new AdService(service);
            var ad = adService.CreateAd(model);
            await context.Ads.AddAsync(ad);
            await context.SaveChangesAsync();
            return Ok(ad);
        }

        [HttpPut("v1/ads/{id}")]
        public async Task<IActionResult> EditAdAsync(
            [FromRoute] int id,
            [FromBody] AdViewModel model,
            [FromServices] IExternalAdService service,
            [FromServices] AdDataContext context)
        {
            var oldAd = await context.Ads.FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                var adService = new AdService(service);
                var ad = adService.EditAd(oldAd, model);
                context.Update(ad);
                await context.SaveChangesAsync();
                return Ok(ad);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("v1/ads/{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id,
            [FromServices] AdDataContext context)
        {
            try
            {
                var ad = await context.Ads.FirstOrDefaultAsync(x => x.Id == id);
                context.Remove(ad);
                await context.SaveChangesAsync();

                return Ok(ad);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
