using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Validation;
using MovieStore_Application.Models.DTOs.StarringDTOS;
using MovieStore_Application.Services.MovieServices;
using MovieStore_Application.Services.StarringServices;

namespace MovieStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class StarringController : Controller
    {
        private readonly IStarringService _starringService;
        private readonly IMovieService _movieService;
       

        public StarringController(IStarringService starringRepository, IMovieService movieService)
        {
            _starringService = starringRepository;
            _movieService = movieService;
           
        }
        public async Task<IActionResult> Index()
        {
            var starrings = await _starringService.GetStarrings();
            return View (starrings);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateStarringDTO newStarring)
        {
            StarringValidation validator = new StarringValidation();
            var result = validator.Validate(newStarring);

            if (result.IsValid)
            {
                await _starringService.Create(newStarring);
                TempData["success"] = "New Starring is added successfully";
                return RedirectToAction("Index");
            }
            //ToDo : Kontrol Edilecek
            //result.AddToModelState(this.ModelState);
            return View(newStarring);

        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            return View(await _starringService.GetById(id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateStarringDTO updatedStarring)
        {
            StarringValidation1 validator = new StarringValidation1();
            var result = validator.Validate(updatedStarring);
            if (result.IsValid)
            {
                await _starringService.Update(updatedStarring);
                TempData["success"] = "Starring is updated successfully";
                return RedirectToAction("Index");
            }
            //ToDo : Kontrol Edilecek
            //result.AddToModelState(this.ModelState);
            return View(updatedStarring);

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            return View(await _starringService.GetById(id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _starringService.Delete(id);
            TempData["success"] = "Starring is deleted successfully";
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            //ToDo
            //ViewBag.Starrings = new SelectList(_starringService.GetById(id).FullName);
            //ViewBag.PerformedMovies = new SelectList(_starringService.GetById(id).PerformedMovies, "Id", "Name");

            return View(await _starringService.GetById(id));
        }
    }
}
