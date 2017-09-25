using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentalTrackers.Models;
using RentalTrackers.ViewModels;

namespace RentalTrackers.Controllers
{
    public class MangasController : Controller
    {
        // GET: Manga
        public ViewResult Index()
        {
            var manga = GetMangas();
            return View(manga);
        }

        private IEnumerable<Manga> GetMangas()
        {
            return new List<Manga>
            {
                new Manga { Id = 1, Name = "Naruto" },
                new Manga { Id = 2, Name = "Bleach" }
            };
        }

        // GET: Movies/Random
        public ViewResult Random()
        {
            var manga = new Manga() { Name = "Naruto!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 3" },
                new Customer { Name = "Customer 4" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Manga = manga,
                Customers = customers
            };

            return View(viewModel);
        }
    }
}