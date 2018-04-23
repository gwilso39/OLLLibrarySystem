using System;
using System.Collections.Generic;
using System.Text;
using OLLLibrarySystem.Domain.Abstract;
using OLLLibrarySystem.Domain.Entities;

namespace OLLLibrarySystem.Domain.Concrete
{
    public class EFEntitiesRepository : IEntitiesRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Book> Book { get { return context.Book; } }
        public IEnumerable<Access> Access { get { return context.Access; } }
        public IEnumerable<Age> Age { get { return context.Age; } }
        public IEnumerable<CheckedOutIn> CheckedOutIn { get { return context.CheckedOutIn; } }
        public IEnumerable<Lexile> Lexile { get { return context.Lexile; } }
        public IEnumerable<Location> Location { get { return context.Location; } }
        public IEnumerable<Media> Media { get { return context.Media; } }
        public IEnumerable<Subject> Subject { get { return context.Subject; } }
        public IEnumerable<User> User { get { return context.User; } }
    }
}
