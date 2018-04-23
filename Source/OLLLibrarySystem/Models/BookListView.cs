using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OLLLibrarySystem.Domain.Entities;

namespace OLLLibrarySystem.WebUI.Models
{
    public class BookListViewModel
    {
        public IEnumerable<Book> Book { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentGenre { get; set; }
    }
}