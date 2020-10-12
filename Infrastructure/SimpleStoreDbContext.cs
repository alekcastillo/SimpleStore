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
        public DbSet<Consecutive> Consecutives { get; set; }
    }
}
