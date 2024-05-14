using IORoute.Data.Protocols;
using IORoute.Domain.Models.DTO;
using IORoute.Infra.Persistence;

namespace IORoute.Infra.Repositories
{
    public class RoutesRepository : ILoadRoutesRepository
    {
        private readonly RouteContext _dbContext;

        public RoutesRepository(RouteContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<RouteModel> LoadRoutes()
        {
            var routes = _dbContext.Routes.ToList();
            var routeModels = routes.Select(route => new RouteModel
            {
                Origin = route.Origin,
                Destination = route.Destination,
                Cost = route.Cost
            });
            return routeModels;
        }
    }
}
