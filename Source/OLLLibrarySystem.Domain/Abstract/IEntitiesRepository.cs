using System;
using System.Collections.Generic;
using OLLLibrarySystem.Domain.Entities;
using System.Text;

namespace OLLLibrarySystem.Domain.Abstract
{
    public interface IEntitiesRepository
    {
        IEnumerable<Access> Access { get; }
        IEnumerable<Age> Age { get; }
        IEnumerable<Book> Book { get; }
        IEnumerable<CheckedOutIn> CheckedOutIn { get; }
        IEnumerable<Location> Location { get; }
        IEnumerable<Media> Media { get; }
        IEnumerable<Subject> Subject { get; }
        IEnumerable<Users> Users { get; }
    }
}
