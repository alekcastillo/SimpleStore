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
        public DbSet<DownloadLog> DownloadLogs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<PaymentMethodCard> PaymentMethodCards { get; set; }
        public DbSet<PaymentMethodEasyPay> PaymentMethodEasyPays { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBook> ProductBooks { get; set; }
        public DbSet<ProductBookSubject> ProductBookSubjects { get; set; }
        public DbSet<ProductMovie> ProductMovies { get; set; }
        public DbSet<ProductMovieActor> ProductMovieActors { get; set; }
        public DbSet<ProductMovieGenre> ProductMovieGenres { get; set; }
        public DbSet<ProductSong> ProductSongs { get; set; }
        public DbSet<ProductSongGenre> ProductSongGenres { get; set; }
        public DbSet<SystemConfiguration> SystemConfigurations { get; set; }
        public DbSet<TableConsecutive> TableConsecutives { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<ChangeLog> ChangeLogs { get; set; }

        public SimpleStoreDbContext(DbContextOptions<SimpleStoreDbContext> options)
            : base(options) {}

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
    }
}
