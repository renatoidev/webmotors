using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMotors.Data;
using WebMotors.Extensions;
using WebMotors.Interfaces;
using WebMotors.Models;
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
            try
            {
                var ads = await context.Ads
                    .AsNoTracking()
                    .ToListAsync();
                if (ads == null)
                    return NotFound(new ResultViewModel<string>("Conteúdo não encontrado"));

                return Ok(new ResultViewModel<List<Ad>>(ads));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<string>("Erro interno no servidor"));
            }
        }

        [HttpGet("v1/ads/{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute]int id,
            [FromServices] AdDataContext context)
        {
            try
            {
                var ad = await context.Ads
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (ad == null)
                    return NotFound(new ResultViewModel<Ad>("Conteúdo não encontrado"));

                return Ok(new ResultViewModel<Ad>(ad));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<string>("Erro interno no servidor"));
            }
        }

        [HttpPost("v1/ads")]
        public async Task<IActionResult> CreateAdAsync(
            [FromBody] AdViewModel model,
            [FromServices] IExternalAdService service,
            [FromServices] AdDataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Ad>(ModelState.GetErrors()));
            try
            {
                var adService = new AdService(service);
                var ad = adService.CreateAd(model);
                await context.Ads.AddAsync(ad);
                await context.SaveChangesAsync();
                return Created($"v1/ads/{ad.Id}", ad);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<string>("Erro Interno no servidor"));
            }
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
                if (oldAd == null)
                    return NotFound(new ResultViewModel<Ad>("Nâo encontrado"));

                var adService = new AdService(service);
                var ad = adService.EditAd(oldAd, model);
                context.Update(ad);
                await context.SaveChangesAsync();
                return Ok(new ResultViewModel<Ad>(ad));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<string>("Erro interno no servidor"));
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

                if (ad == null)
                    return NotFound(new ResultViewModel<Ad>("Não encontrado"));

                context.Remove(ad);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Ad>(ad));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Ad>("Houve uma falha ao tentar excluir"));
            }
        }
    }
}
