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
    public class CartController : Controller
    {
        private IEntitiesRepository repository;

        public CartController(IEntitiesRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(int bookId, string returnUrl)
        {
            Book book = repository.Book
                .FirstOrDefault(p => p.BookID == bookId);

            if (book != null)
            {
                GetCart().AddItem(book, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int bookId, string returnUrl)
        {
            Book book = repository.Book
                .FirstOrDefault(p => p.BookID == bookId);

            if (book != null)
            {
                GetCart().RemoveLine(book);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart()
        {

            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}