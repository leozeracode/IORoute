using IORoute.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace IORoute.Infra.Persistence
{
    public class RouteContext : DbContext
    {
        public RouteContext(DbContextOptions<RouteContext> options) : base(options)
        {
        }

        public DbSet<Route> Routes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Route>()
                .Property(o => o.Cost)
                .HasColumnType("decimal(18,2)");
        }
    }
}
