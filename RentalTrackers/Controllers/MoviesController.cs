using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using RentalTrackers.Models;
using RentalTrackers.ViewModels;

namespace RentalTrackers.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            //var movies = GetMovies();
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);    
        }


        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }

        public ActionResult Edit(int id)
        {
            var movieInDb = _context.Movies.Single(c => c.Id == id);
            //movieInDb.Name = movieInDb.Name;
            //movieInDb.ReleaseDate = movieInDb.ReleaseDate;
            //movieInDb.Genre = movieInDb.Genre;
            //movieInDb.NumberInStock = movieInDb.NumberInStock;
            var viewModel = new MovieFormViewModel(movieInDb)
            {
                Genres = _context.Genres.ToList(),
                Title = "Edit Movie Info"
            };
            return View("MovieForm", viewModel);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Wall-e" }
            };
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            //var movie = _context.Movies.Include(i => i.MovieInfo).SingleOrDefault(j => j.Id == id);

            return View(viewModel);
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel() { Genres = genres, Title= "New Movie" };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    DateAdded = movie.DateAdded,
                    GenreId = movie.GenreId,
                    Name = movie.Name,
                    NumberInStock= movie.NumberInStock,
                    ReleaseDate = movie.ReleaseDate,
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
    }
}