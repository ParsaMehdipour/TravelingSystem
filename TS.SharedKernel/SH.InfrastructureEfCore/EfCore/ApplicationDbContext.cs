using Microsoft.EntityFrameworkCore;
using SH.Application.Interfaces;
using SH.Domain;

namespace SH.InfrastructureEfCore.EfCore;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    protected ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    //public constructor for efcore
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    break;

                case EntityState.Modified:
                    entry.Entity.ModifiedDate = DateTime.Now;
                    break;
            }
        }

        var result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }
}