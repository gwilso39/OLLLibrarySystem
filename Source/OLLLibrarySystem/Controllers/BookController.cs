using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLLLibrarySystem.Domain.Abstract;
using OLLLibrarySystem.Domain.Entities;

namespace OLLLibrarySystem.WebUI.Controllers
{
    public class BookController : Controller
    {
        private IEntitiesRepository repository;

        public BookController(IEntitiesRepository bookRepository)
        {
            this.repository = bookRepository;
        }

        public ViewResult List()
        {
            return View(repository.Book);
        }
    }
}