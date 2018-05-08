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
        public IEnumerable<Location> Location { get { return context.Location; } }
        public IEnumerable<Media> Media { get { return context.Media; } }
        public IEnumerable<Subject> Subject { get { return context.Subject; } }
        public IEnumerable<Users> Users { get { return context.Users; } }

        public void SaveBook(Book book)
        {
            if (book.BookID == 0)
            {
                context.Book.Add(book);
            }
            else
            {
                Book dbEntry = context.Book.Find(book.BookID);
                if (dbEntry != null)
                {
                    dbEntry.BookTitle = book.BookTitle;
                    dbEntry.LexileUpper = book.LexileUpper;
                    dbEntry.LexileLower = book.LexileLower;
                    dbEntry.LocationID = book.LocationID;
                    dbEntry.CheckedOutInID = book.CheckedOutInID;
                    dbEntry.RecAge = book.RecAge;
                    dbEntry.Author = book.Author;
                    dbEntry.Genre = book.Genre;
                    dbEntry.Description = book.Description;
                    dbEntry.Photo = book.Photo;
                    dbEntry.ReplacementCost = book.ReplacementCost;
                    dbEntry.ISBN = book.ISBN;
                }
            }
            context.SaveChanges();
        }

        public Book DeleteBook(int bookID)
        {
            Book dbEntry = context.Book.Find(bookID);
            if(dbEntry != null)
            {
                context.Book.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
