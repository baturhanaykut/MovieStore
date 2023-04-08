using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStore_Application.Models.DTOs.DirectorDTOS;
using MovieStore_Application.Services.DirectorServices;

namespace MovieStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DirectorController : Controller
    {
        private readonly IDirectorService _directorService;

        public DirectorController(IDirectorService directorService)
        {
            _directorService = directorService;

        }
        public async Task<IActionResult> Index()
        {
            return View(await _directorService.GetDirectors());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDirectorDTO newDirector)
        {
            if (ModelState.IsValid)
            {
                await _directorService.Create(newDirector);
                TempData["success"] = "New Director is added successfully";
                return RedirectToAction("Index");
            }
            return View(newDirector);

        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            return View(await _directorService.GetDirectorDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateDirectorDTO updatedDirector)
        {
            if (ModelState.IsValid)
            {
                await _directorService.Update(updatedDirector);
                TempData["success"] = "Director is updated successfully";
                return RedirectToAction("Index");
            }
            return View(updatedDirector);

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            return View(await _directorService.GetDirectorDetails(id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _directorService.Delete(id);
            TempData["success"] = "Director is deleted successfully";
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            //Todo Viebag Düzeltmesi yapılacak.
            //ViewBag.DirectedMovies = new SelectList(_directorService.GetById(id).DirectedMovies, "Id", "Name");

            return View(await _directorService.GetDirectorDetails(id));
        }
    }
}
