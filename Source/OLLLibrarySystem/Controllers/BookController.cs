using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLLLibrarySystem.Domain.Abstract;
using OLLLibrarySystem.Domain.Entities;
using OLLLibrarySystem.WebUI.Models;

namespace OLLLibrarySystem.WebUI.Controllers
{
    public class BookController : Controller
    {
        private IEntitiesRepository repository;
        public int PageSize = 2;

        public BookController(IEntitiesRepository bookRepository)
        {
            this.repository = bookRepository;
        }

        public ViewResult List(string genre, int page = 1)
        {
            BookListViewModel model = new BookListViewModel
            {
                Book = repository.Book
                            .Where(p => genre == null || p.Genre == genre)
                            .OrderBy(p => p.BookID)
                            .Skip((page - 1) * PageSize)
                            .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = genre == null ?
                        repository.Book.Count() :
                        repository.Book.Where(e => e.Genre == genre).Count()
                },
                CurrentGenre = genre
            };
            return View(model);
        }
    }
}