using IORoute.Domain.Models.DTO;

namespace IORoute.App.Protocols
{
    public interface ILoadRoutesRepository
    {
        Task<IEnumerable<RouteModel>> LoadRoutes();
    }
}
