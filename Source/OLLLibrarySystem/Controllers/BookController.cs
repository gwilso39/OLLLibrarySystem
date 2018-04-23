using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLLLibrarySystem.Domain.Abstract;
using OLLLibrarySystem.Domain.Entities;
using OLLLibrarySystem.WebUI.Models;

namespace OLLLibrarySystem.Controllers
{
    public class BookController : Controller
    {
        private IEntitiesRepository repository;
        public int PageSize = 4;

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