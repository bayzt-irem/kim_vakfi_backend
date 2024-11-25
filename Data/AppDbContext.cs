using Items.Command.User;
using Items.Entities;
using Microsoft.EntityFrameworkCore;
using OperationClaim = Items.Entities.OperationClaim;

namespace Data.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; } 
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }  

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var addedEntries = ChangeTracker.Entries()
                                            .Where(x => x.State == EntityState.Added)
                                            .ToList();

            addedEntries.ForEach(added =>
            {
                if (added.Entity is EntityBase)
                {
                    added.Property("CreatedAt").CurrentValue = DateTime.Now.ToUniversalTime();
                    added.Property("ModifiedAt").CurrentValue = DateTime.Now.ToUniversalTime();
                }
            });

            var updatedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified).ToList();

            updatedEntries.ForEach(added =>
            {
                if (added.Entity is EntityBase)
                {
                    added.Property("ModifiedAt").CurrentValue = DateTime.Now;
                }
            });

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
