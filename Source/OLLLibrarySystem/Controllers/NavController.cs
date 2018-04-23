using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLLLibrarySystem.Domain.Abstract;

namespace OLLLibrarySystem.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IEntitiesRepository repository;

        public NavController(IEntitiesRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(string genre = null)
        {

            ViewBag.SelectedGenre = genre;

            IEnumerable<string> genres = repository.Book
                                    .Select(x => x.Genre)
                                    .Distinct()
                                    .OrderBy(x => x);

            return PartialView(genres);
        }
    }
}