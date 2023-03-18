using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieStore.Models.Entities;
using MovieStore.Models.ViewModels;
using MovieStore.Repository.Abstract;
using MovieStore.Repository.Concerete;
using MovieStore.Validation;

namespace MovieStore.Controllers
{
    public class StarringController : Controller
    {
        private readonly IStarringRepository _repository;
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public StarringController(IStarringRepository starringRepository, IMapper mapper, IMovieRepository movieRepository)
        {
            _repository = starringRepository;
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            List<StarringVM> starrings = new List<StarringVM>();
            foreach (var item in _repository.GetAll())
            {
                starrings.Add(_mapper.Map<StarringVM>(item));
            }
            return View(starrings);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(StarringVM newStarring)
        {
            StarringValidation validator = new StarringValidation();
            var result = validator.Validate(newStarring);

            if (result.IsValid)
            {
                _repository.Add(_mapper.Map<Starring>(newStarring));
                TempData["success"] = "New Starring is added successfully";
                return RedirectToAction("Index");
            }
            result.AddToModelState(this.ModelState);       
            return View(newStarring);

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {

            return View(_mapper.Map<StarringVM>(_repository.GetById(id)));
        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Edit(StarringVM updatedStarring)
        {
            StarringValidation validator = new StarringValidation();
            var result = validator.Validate(updatedStarring);
            if (result.IsValid)
            {
                _repository.Update(_mapper.Map<Starring>(updatedStarring));
                TempData["success"] = "Starring is updated successfully";
                return RedirectToAction("Index");
            }
            result.AddToModelState(this.ModelState);
            return View(updatedStarring);

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            return View(_mapper.Map<StarringVM>(_repository.GetById(id)));
        }

        [HttpPost, ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            TempData["success"] = "Starring is deleted successfully";
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Details(int id)
        {

            ViewBag.Starrings = new SelectList(_repository.GetById(id).FullName);
            ViewBag.PerformedMovies = new SelectList(_repository.GetById(id).PerformedMovies, "Id", "Name");

            return View(_mapper.Map<StarringVM>(_repository.GetById(id)));
        }




    }
}
