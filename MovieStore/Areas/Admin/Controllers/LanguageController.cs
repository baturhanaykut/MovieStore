using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStore_Application.Models.DTOs.LanguageDTOS;
using MovieStore_Application.Services.LanguageServices;

namespace MovieStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class LanguageController : Controller
    {

        private readonly ILanguageService _languageservice;


        public LanguageController(ILanguageService languagerepository)
        {
            _languageservice = languagerepository;
        }

        public async Task<IActionResult> Index()
        {
            var language = await _languageservice.GetLanguages();
            return View(language);

        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateLanguageDTO newLanguage)
        {
            if (ModelState.IsValid)
            {
                await _languageservice.Create(newLanguage);
                TempData["success"] = "New Language is added successfully";
                return RedirectToAction("Index");
            }
            return View(newLanguage);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _languageservice.GetById(id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateLanguageDTO updatedLanguage)
        {
            if (ModelState.IsValid)
            {
                await _languageservice.Update(updatedLanguage);
                TempData["success"] = "Language is updates successfully";
                return RedirectToAction("Index");
            }
            return View(updatedLanguage);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _languageservice.GetById(id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteComfirmed(int id)
        {
            await _languageservice.Delete(id);
            TempData["success"] = "Language is deleted successfully";
            return RedirectToAction("Index");
        }

        
    }
}
