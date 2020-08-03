using Project1.Models;
using Project1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1.Controllers
{
    public class MovieController : Controller
    {

        private MyDBContext _context;
        public MovieController()
        {
            _context = new MyDBContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movie

        [Route("Movies/AddNewMovie")]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewMovie(Movie movie)
        {
            if (movie.Id == 0)
            {
                
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.Genre = movie.Genre;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;

            }
            
            try
            { 
                 _context.SaveChanges();
            }
            catch
            {
                return View("CreateNewMovie", movie);
            }

            return RedirectToAction("Movies", "Movie");


        }
        

        [Route("Movies/New")]


        public ActionResult CreateNewMovie()
        {
            return View();
        }
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name="Customer 1" },
                new Customer { Name="Customer 2" }

            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            
            return View(viewModel);
        }

        public ActionResult Customers()
        {
            var movie = new Movie() { Name = "Shrek" };
            var movie2 = new Movie() { Name = "Inside Out" };
            var customers = new List<Customer>
            {
                new Customer { Name="John Doe" },
                new Customer { Name="Samantha Becker" }

            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        [Route("Movies")]
        public ActionResult Movies()
        {

            var movies = _context.Movies.ToList();
            


            var movieList = new MovieListViewModel
            {
                Movies = movies 
            };



            return View(movieList);
        }

        [Route("Movies/Edit/{id}")]
        public ActionResult MovieEdit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        // movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));



        }
        [Route("movies/released/{year:regex(\\d{4}):range(1800, 2200)}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

    }
}