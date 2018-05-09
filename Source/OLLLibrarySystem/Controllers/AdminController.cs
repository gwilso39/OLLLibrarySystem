using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLLLibrarySystem.Domain.Abstract;
using OLLLibrarySystem.Domain.Entities;

namespace OLLLibrarySystem.WebUI.Controllers
{
    [Authorize]
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
        public ActionResult Edit(Book book, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    book.PhotoMimeType = image.ContentType;
                    book.PhotoData = new byte[image.ContentLength];
                    image.InputStream.Read(book.PhotoData, 0, image.ContentLength);
                }

                repository.SaveBook(book);
                TempData["message"] = string.Format("{0} has been saved", book.BookTitle);
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

        [HttpPost]
        public ActionResult Delete(int bookId)
        {
            Book deletedBook = repository.DeleteBook(bookId);
            if (deletedBook != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                    deletedBook.BookTitle);
            }
            return RedirectToAction("Index");
        }
    }
}