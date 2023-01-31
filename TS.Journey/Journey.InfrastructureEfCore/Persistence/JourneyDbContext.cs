using Microsoft.EntityFrameworkCore;
using SH.InfrastructureEfCore.EfCore;
using System.Reflection;

namespace Journey.InfrastructureEfCore.Persistence;

public class JourneyDbContext : ApplicationDbContext
{

    public JourneyDbContext(DbContextOptions<JourneyDbContext> opt) : base(opt)
    {

    }

    public DbSet<Domain.Models.Journey> Journeys { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
