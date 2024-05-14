using IORoute.Domain.Models.DTO;

namespace IORoute.Domain.Usecases
{
    public interface IGetBestRoute
    {
        Task<string> GetRoute(RouteModelViewModel model);
    }
}
