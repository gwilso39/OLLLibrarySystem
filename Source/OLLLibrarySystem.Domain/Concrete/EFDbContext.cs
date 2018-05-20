using System;
using System.Collections.Generic;
using System.Text;
using OLLLibrarySystem.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OLLLibrarySystem.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Book> Book { get; set; }
        public DbSet<Access> Access { get; set; }
        public DbSet<Age> Age { get; set; }
        public DbSet<CheckedOutIn> CheckedOutIn { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Users> Users { get; set; }

    }
}
