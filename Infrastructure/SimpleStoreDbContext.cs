using Microsoft.EntityFrameworkCore;
using SimpleStore.Models;
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

        public DbSet<User> Users { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Disk> Disks { get; set; }
        public DbSet<Download> Downloads { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<Singer> Singers { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<TypeInterpretation> TypeInterpretations { get; set; }
    }
}
