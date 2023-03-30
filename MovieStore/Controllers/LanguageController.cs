using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieStore.Models.Entities;
using MovieStore.Models.ViewModels;
using MovieStore_Domain.Repository;

namespace MovieStore.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ILanguageRepository _repository;
        private readonly IMapper _mapper;

        public LanguageController(ILanguageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            List<LanguageVM> language = new List<LanguageVM>();
            foreach (var item in _repository.GetAll())
            {
                language.Add(_mapper.Map<LanguageVM>(item));
            }
            return View(language);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(LanguageVM newLanguage)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(_mapper.Map<Language>(newLanguage));
                TempData["success"] = "New Language is added successfully";
                return RedirectToAction("Index");
            }
            return View(newLanguage);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_mapper.Map<LanguageVM>(_repository.GetById(id)));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(LanguageVM updatedLanguage)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(_mapper.Map<Language>(updatedLanguage));
                TempData["success"] = "Language is updates successfully";
                return RedirectToAction("Index");
            }
            return View(updatedLanguage);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_mapper.Map<LanguageVM>(_repository.GetById(id)));
        }

        [HttpPost,ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeleteComfirmed(int id)
        {
            _repository.Delete(id);
            TempData["success"] = "Language is deleted successfully";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {

            ViewBag.DirectedMovies = new SelectList(_repository.GetById(id).OriginalLanguageOfMovies, "Id", "Name");

            return View(_mapper.Map<LanguageVM>(_repository.GetById(id)));
        }
    }
}
