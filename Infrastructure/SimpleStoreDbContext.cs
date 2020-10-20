using Microsoft.EntityFrameworkCore;
using SimpleStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleStore.Infrastructure
{
    public class SimpleStoreDbContext : DbContext
    {
        public SimpleStoreDbContext(DbContextOptions<SimpleStoreDbContext> options)
            : base(options)
        { }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries().Where(
                e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                var baseEntity = (BaseEntity)entityEntry.Entity;
                baseEntity.UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                    baseEntity.CreatedDate = DateTime.Now;
            }

            return base.SaveChanges();
        }

        public DbSet<User> Users { get; set; }
        //public DbSet<Consecutive> Consecutives { get; set; }
    }
}
