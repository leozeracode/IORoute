using IORoute.Domain.Models.Entities;
using IORoute.Infra.Persistence;
using IORoute.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IORoute.Test.Infra.Repositories
{
    public class LoadRoutesRepositoryTests
    {
        [Fact]
        public void LoadRoutes_ShouldReturn_Routes()
        {
            var options = new DbContextOptionsBuilder<RouteDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) 
                .Options;

            using (var context = new RouteDbContext(options))
            {
                context.Routes.Add(new Route { Origin = "GRU", Destination = "BRC", Cost = 10 });
                context.Routes.Add(new Route { Origin = "BRC", Destination = "SCL", Cost = 5 });
                context.Routes.Add(new Route { Origin = "GRU", Destination = "CDG", Cost = 75 });
                context.Routes.Add(new Route { Origin = "GRU", Destination = "SCL", Cost = 20 });
                context.Routes.Add(new Route { Origin = "GRU", Destination = "ORL", Cost = 56 });
                context.Routes.Add(new Route { Origin = "ORL", Destination = "CDG", Cost = 5 });
                context.Routes.Add(new Route { Origin = "SCL", Destination = "ORL", Cost = 20 });

                context.SaveChanges();
            }

            using (var context = new RouteDbContext(options))
            {
                var repository = new RoutesRepository(context);
                var routes = repository.LoadRoutes();

                Assert.NotNull(routes);
                Assert.Equal(7, routes.Count()); 
            }
        }
    }
}
