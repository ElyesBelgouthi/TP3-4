using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TP3.Models;
using TP3.Services.ServicesContracts;

namespace TP3.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IMoviesService _moviesService;

        public MoviesController(ApplicationDbContext db, IMoviesService _movieService)
        {
            _db = db;
            _moviesService = _movieService;

        }
        public IActionResult Index()
        {

            return View(_moviesService.GetAllMovies());
        }

        public IActionResult Create()
        {
            ViewData["Genres"] = new SelectList(_db.Set<Genre>(), "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMovie(Movie movie)
        {

            if (ModelState.IsValid)
            {
                _moviesService.CreateMovie(movie);
                return RedirectToAction("Index");
            }
            ViewData["Genres"] = new SelectList(_db.Set<Genre>(), "Id", "Id");
            ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return View("Create", movie);
        }

        public IActionResult MoviesByGenre(int id)
        {
            var movies = _moviesService.GetMoviesByGenre(id);
            return View("Index", movies);
        }


        public IActionResult MoviesOrderedAscending()
        {
            var movies = _moviesService.GetAllMoviesOrderedAscending();
            return View("Index", movies);
        }

        public IActionResult MoviesByUserDefinedGenre(string name)
        {
            var movies = _moviesService.GetMoviesByUserDefinedGenre(name);
            return View("Index", movies);
        }
    }
}