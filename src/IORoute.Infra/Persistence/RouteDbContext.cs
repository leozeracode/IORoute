using IORoute.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace IORoute.Infra.Persistence
{
    public class RouteDbContext : DbContext
    {
        public RouteDbContext(DbContextOptions<RouteDbContext> options) : base(options)
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
