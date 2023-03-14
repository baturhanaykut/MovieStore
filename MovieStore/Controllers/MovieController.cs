using Microsoft.AspNetCore.Mvc;
using MovieStore.Models.Entities;
using MovieStore.Repository.Abstract;

namespace MovieStore.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public IActionResult Index()
        {

            return View(_movieRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            _movieRepository.Add(movie);
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
            return View(_movieRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {

            _movieRepository.Update(movie);
            return RedirectToAction("Index");

        }


        public IActionResult Delete(int id)
        {
            return View(_movieRepository.GetById(id));
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _movieRepository.Delete(id);
            return RedirectToAction("Index");

        }

        public IActionResult Details(int id)
        {
            return View(_movieRepository.GetById(id));
        }

    }
}
