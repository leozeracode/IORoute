using IORoute.Domain.Models.DTO;

namespace IORoute.App.Protocols
{
    public interface ILoadRoutesRepository
    {
        IEnumerable<RouteModel> LoadRoutes();
    }
}
