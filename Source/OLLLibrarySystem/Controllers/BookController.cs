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
        public int PageSize = 4;

        public BookController(IEntitiesRepository bookRepository)
        {
            this.repository = bookRepository;
        }

        public ViewResult List(int page = 1)
        {
            BookListViewModel model = new BookListViewModel
            {
                Book = repository.Book
                            .OrderBy(p => p.BookID)
                            .Skip((page - 1) * PageSize)
                            .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Book.Count()
                }
            };
            return View(model);
        }
    }
}