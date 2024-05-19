using IORoute.App.Protocols;
using IORoute.Domain.Models.DTO;
using IORoute.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IORoute.Infra.Repositories
{
    public class RoutesRepository : ILoadRoutesRepository
    {
        private readonly RouteDbContext _dbContext;

        public RoutesRepository(RouteDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<RouteModel>> LoadRoutes()
        {
            var routes = await _dbContext.Routes.ToListAsync();
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
