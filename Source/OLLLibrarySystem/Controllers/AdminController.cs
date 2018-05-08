using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLLLibrarySystem.Domain.Abstract;
using OLLLibrarySystem.Domain.Entities;

namespace OLLLibrarySystem.Controllers
{
    public class AdminController : Controller
    {
        private IEntitiesRepository repository;

        public AdminController(IEntitiesRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Book);
        }

        public ViewResult Edit(int bookId)
        {
            Book book = repository.Book
                .FirstOrDefault(p => p.BookID == bookId);
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                repository.SaveBook(book);
                TempData["message"] = string.Format("{0} has been saved", book.Title);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(book);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Book());
        }

        //[HttpPost]
        //public ActionResult Delete(int bookId)
        //{
        //    Book deletedBook = repository.DeleteBook(bookId);
        //    if (deletedBook != null)
        //    {
        //        TempData["message"] = string.Format("{0} was deleted",
        //            deletedBook.Title);
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}