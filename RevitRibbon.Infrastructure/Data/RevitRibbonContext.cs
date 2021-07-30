using RevitRibbon.Database.Common;
using RevitRibbon.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RevitRibbon.Infrastructure.Data
{
    public class RevitRibbonContext : DbContext
    {
        public RevitRibbonContext(DbContextOptions<RevitRibbonContext> options) : base(options)
        {
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<Script> Scripts { get; set; }
        public DbSet<SharedParameter> SharedParameters { get; set; }
        public DbSet<SharedParameterGroup> SharedParameterGroups { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is AuditableEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((AuditableEntity)entityEntry.Entity).LastModified = DateTime.UtcNow;

                if (entityEntry.State == EntityState.Added)
                {
                    ((AuditableEntity)entityEntry.Entity).Created = DateTime.UtcNow;
                }
            }
            return await base.SaveChangesAsync().ConfigureAwait(false);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Group>()
                .HasIndex(group => group.Name)
                .IsUnique();

            builder.Entity<Script>()
                .HasIndex(script => script.Name)
                .IsUnique();

            builder.Entity<SharedParameter>()
                .HasIndex(script => script.Name)
                .IsUnique();

            builder.Entity<SharedParameterGroup>()
                .HasIndex(script => script.Name)
                .IsUnique();
        }
    }
}