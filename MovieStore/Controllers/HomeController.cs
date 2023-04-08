using Microsoft.AspNetCore.Mvc;
using MovieStore_Application.Models.VMs.MovieVM;
using MovieStore_Application.Services.MovieServices;

namespace MovieStore.Before_Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;

        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            List <MovieVM> movies = await _movieService.GetMovies();
            return View(movies);
        }
    }
}
