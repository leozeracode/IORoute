using IORoute.Domain.Models.DTO;

namespace IORoute.Data.Protocols
{
    public interface ILoadRoutesRepository
    {
        IEnumerable<RouteModel> LoadRoutes();
    }
}
