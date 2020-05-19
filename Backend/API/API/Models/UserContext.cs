using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class UserContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => new { u.email, u.phone, u.documentNumber})
                .IsUnique(true);
        }
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
    }
}
