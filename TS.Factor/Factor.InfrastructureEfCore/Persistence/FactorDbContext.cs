using Microsoft.EntityFrameworkCore;
using SH.InfrastructureEfCore.EfCore;
using System.Reflection;

namespace Factor.InfrastructureEfCore.Persistence;

public class FactorDbContext : ApplicationDbContext
{
    public FactorDbContext(DbContextOptions<FactorDbContext> opt) : base(opt)
    {

    }

    public DbSet<Domain.Models.Factor> Factors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

