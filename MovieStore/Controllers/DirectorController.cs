using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieStore.Models.Entities;
using MovieStore.Models.ViewModels;
using MovieStore_Domain.Repository;
using NuGet.Protocol.Core.Types;

namespace MovieStore.Controllers
{
    public class DirectorController : Controller
    {
        private readonly IDirectorRepository _directorRepository;
        private readonly IMapper _mapper;

        public DirectorController(IDirectorRepository directorRepository, IMapper mapper)
        {
            _directorRepository = directorRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            List<DirectorVM> directors = new List<DirectorVM>();
            foreach (var item in _directorRepository.GetAll())
            {
                directors.Add(_mapper.Map<DirectorVM>(item));
            }
            return View(directors);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(DirectorVM newDirector)
        {
            if (ModelState.IsValid)
            {
                _directorRepository.Add(_mapper.Map<Director>(newDirector));
                TempData["success"] = "New Director is added successfully";
                return RedirectToAction("Index");
            }
            return View(newDirector);
            
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {

            return View(_mapper.Map<DirectorVM>(_directorRepository.GetById(id)));
        }

        [HttpPost]
        public IActionResult Edit(DirectorVM updatedDirector)
        {
            if (ModelState.IsValid)
            {
                _directorRepository.Update(_mapper.Map<Director>(updatedDirector));
                TempData["success"] = "Director is updated successfully";
                return RedirectToAction("Index");
            }
            return View(updatedDirector);
            
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            return View(_mapper.Map<DirectorVM>(_directorRepository.GetById(id)));
        }

        [HttpPost, ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _directorRepository.Delete(id);
            TempData["success"] = "Director is deleted successfully";
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            

            ViewBag.DirectedMovies = new SelectList(_directorRepository.GetById(id).DirectedMovies, "Id", "Name");

            return View(_mapper.Map<DirectorVM>(_directorRepository.GetById(id)));
        }



    }
}
