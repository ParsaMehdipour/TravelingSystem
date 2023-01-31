using Microsoft.EntityFrameworkCore;
using SH.InfrastructureEfCore.EfCore;
using System.Reflection;

namespace Driver.InfrastructureEfCore.Persistence;

public class DriverDbContext : ApplicationDbContext
{
    public DriverDbContext(DbContextOptions<DriverDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Models.Driver> Drivers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
