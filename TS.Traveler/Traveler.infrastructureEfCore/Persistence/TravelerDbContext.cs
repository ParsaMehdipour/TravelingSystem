using Microsoft.EntityFrameworkCore;
using SH.InfrastructureEfCore.EfCore;
using System.Reflection;

namespace Traveler.infrastructureEfCore.Persistence;

public class TravelerDbContext : ApplicationDbContext
{
    public TravelerDbContext(DbContextOptions<TravelerDbContext> opt) : base(opt)
    {

    }

    public DbSet<Domain.Models.Traveler> Travelers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
