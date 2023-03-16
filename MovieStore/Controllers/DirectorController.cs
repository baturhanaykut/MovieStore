using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieStore.Models.Entities;
using MovieStore.Repository.Abstract;

namespace MovieStore.Controllers
{
    public class DirectorController : Controller
    {
        private readonly IDirectorRepository _directorRepository;

        public DirectorController(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }
        public IActionResult Index()
        {
            return View(_directorRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Director newDirector)
        {
            _directorRepository.Add(newDirector);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_directorRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Director updatedDirector)
        {
            _directorRepository.Update(updatedDirector);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_directorRepository.GetById(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _directorRepository.Delete(id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            var directors = _directorRepository.GetDefault(x => x.Id == id);
            List<Movie> directorMovies = new List<Movie>();
            foreach (var director in directors)
            {
                foreach (var movie in director.DirectedMovies)
                {
                    directorMovies.Add(movie);
                }
                ViewBag.DirectedMovies = new SelectList(directorMovies, "Id", "Name");


            }

            return View(_directorRepository.GetById(id));
        }



    }
}
