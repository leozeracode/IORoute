using IORoute.Domain.Models.DTO;
using IORoute.Domain.Usecases;
using Microsoft.AspNetCore.Mvc;

namespace IORoute.API.Controllers
{
    [Route("api/v1/route")]
    public class RouteController : ControllerBase
    {
        private readonly IGetBestRoute _getBestRoute;
        public RouteController(IGetBestRoute getBestRoute)
        {
            _getBestRoute = getBestRoute;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetBestRoute([FromQuery] RouteModelViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors).Select(e => e.ErrorMessage));
            }
            var bestRoute = await _getBestRoute.GetRoute(model);
            if(bestRoute == null)
            {
                return NotFound("Rota não encontrada.");
            }
            return Ok(bestRoute);
        }
    }
}
