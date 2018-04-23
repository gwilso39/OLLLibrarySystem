using System;
using System.Collections.Generic;
using System.Text;
using OLLLibrarySystem.Domain.Entities;
using System.Data.Entity;

namespace OLLLibrarySystem.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<Access> Access { get; set; }
        public DbSet<Age> Age { get; set; }
        public DbSet<CheckedOutIn> CheckedOutIn { get; set; }
        public DbSet<Lexile> Lexile { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<User> User { get; set; }

    }
}
