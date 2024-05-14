using IORoute.Domain.Models.Entities;
using Microsoft.Extensions.Logging;

namespace IORoute.Infra.Persistence
{
    public class RouteContextSeed
    {
        public static async Task SeedAsync(RouteContext orderContext, ILogger<RouteContextSeed> logger)
        {
            if (!orderContext.Routes.Any())
            {
                orderContext.Routes.AddRange(GetPreconfiguredRoutes());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(RouteContext).Name);
            }
        }

        public static IEnumerable<Route> GetPreconfiguredRoutes()
        {
            return new List<Route>
            {
                new Route { Cost = 10, Destination = "BRC", Origin = "GRU" },
                new Route { Cost = 5, Destination = "SCL", Origin = "BRC" },
                new Route { Cost = 75, Destination = "CDG", Origin = "GRU" },
                new Route { Cost = 20, Destination = "SCL", Origin = "GRU" },
                new Route { Cost = 56, Destination = "ORL", Origin = "GRU" },
                new Route { Cost = 5, Destination = "CDG", Origin = "ORL" },
                new Route { Cost = 20, Destination = "ORL", Origin = "SCL" }
            };
        }
    }
}
