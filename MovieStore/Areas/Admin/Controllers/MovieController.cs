using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;
using MovieStore_Application.Models.DTOs.MovieDTOS;
using MovieStore_Application.Services.CategoryServices;
using MovieStore_Application.Services.DirectorServices;
using MovieStore_Application.Services.LanguageServices;
using MovieStore_Application.Services.MovieServices;
using MovieStore_Application.Services.StarringServices;

namespace MovieStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ICategoryService _categoryService;
        private readonly IDirectorService _directorService;
        private readonly ILanguageService _languageService;
        private readonly IStarringService _starringService;
        private readonly IFileProvider _fileProvider; //Serviste düzenleyicez
        

        public MovieController(IMovieService movieSerivice, ICategoryService categorySerivice, IDirectorService directorerivice, ILanguageService languageService, IStarringService starringService, IFileProvider fileProvider)
        {

            _movieService = movieSerivice;
            _categoryService = categorySerivice;
            _directorService = directorerivice;
            _languageService = languageService;
            _starringService = starringService;
            _fileProvider = fileProvider;
        }


        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetMovies();
            return View(movies);

        }

        public async Task<IActionResult> Create()
        {
            //ToDo Kontrol Edilecek

            CreateMovieDTO createMovieDTO = await _movieService.CreateMovie();

            ViewBag.Categories = new SelectList(createMovieDTO.Categories, "Id", "Name");
            ViewBag.Directors = new SelectList(createMovieDTO.Directors, "Id", "FullName");
            ViewBag.Language = new SelectList(createMovieDTO.Languages, "Id", "Name");
            ViewBag.Starrings = new SelectList(createMovieDTO.Starrings, "Id", "FullName");
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateMovieDTO movie)
        {

            if (ModelState.IsValid)
            {
                await _movieService.Create(movie);
                return RedirectToAction("Index");
             
            }
            //to do createMovieDTOdan çekilecek.
            CreateMovieDTO createMovieDTO = await _movieService.CreateMovie();
            ViewBag.Categories = new SelectList(createMovieDTO.Categories, "Id", "Name");
            ViewBag.Directors = new SelectList(createMovieDTO.Directors, "Id", "FullName");
            ViewBag.Language = new SelectList(createMovieDTO.Languages, "Id", "Name");
            ViewBag.AddStarrignsIds = new SelectList(createMovieDTO.AddStarrignsIds, "Id", "FullName");
            return View(movie);
        }

        public async Task<IActionResult> Edit(int id)
        {
            CreateMovieDTO createMovieDTO = await _movieService.CreateMovie();

            ViewBag.Categories = new SelectList(createMovieDTO.Categories, "Id", "Name");
            ViewBag.Directors = new SelectList(createMovieDTO.Directors, "Id", "FullName");
            ViewBag.Language = new SelectList(createMovieDTO.Languages, "Id", "Name");
            return View(await _movieService.GetById(id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateMovieDTO model)
        {

            if (ModelState.IsValid)
            {
                await _movieService.Update(model);
                return RedirectToAction("Index");
            }

            CreateMovieDTO createMovieDTO = await _movieService.CreateMovie();

            //var starringsThatInPlayMovie = _movieService.GetById((int)model.Id).Starrings;
            //var starringsThatNotInPlayMovie = _starringService.GetAll().Except(starringsThatInPlayMovie);

            ViewBag.Categories = new SelectList(createMovieDTO.Categories, "Id", "Name");
            ViewBag.Directors = new SelectList(createMovieDTO.Directors, "Id", "FullName");
            ViewBag.Language = new SelectList(createMovieDTO.Languages, "Id", "Name");
            //ViewBag.DeleteStarrignsIds = new SelectList(starringsThatInPlayMovie, "Id", "FullName");
            //ViewBag.AddStarrignsIds = new SelectList(starringsThatNotInPlayMovie, "Id", "FullName");
            return View(model);

        }


        public async Task<IActionResult> Delete(int id)
        {
            //ViewBag.Starrings = new SelectList(_movieService.GetById(id).Starrings, "Id", "FullName");
            return View(await _movieService.GetById(id));
        }

        [HttpPost]
        [ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _movieService.Delete(id);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Details(int id)
        {   //Todo
            //ViewBag.Starrings = new SelectList(_movieService.GetById(id).Starrings, "Id", "FullName");
            TempData["Succes"] = "Movie is deleted successfully";
            return View(await _movieService.GetById(id));
        }
    }

}
