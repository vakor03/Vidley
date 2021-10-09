using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Vidley.WebAsp.Models;
using Vidley.WebAsp.ViewModels;

namespace Vidley.WebAsp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();

            return View(movies);
        }

        [Route("Movies/Details/{id}")]
        public ActionResult Details(int id)
        {
            Movie movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie is null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(movie);
            }
        }

        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel
            {
                Genres = _context.Genres
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
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
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie is null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel
            {
                Genres = _context.Genres,
                Movie = movie
            };
            return View("MovieForm", viewModel);
        }
    }
}