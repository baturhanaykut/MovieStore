﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;
using MovieStore.Models.Entities;
using MovieStore.Models.ViewModels;
using MovieStore.Repository.Abstract;

namespace MovieStore.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IDirectorRepository _directorRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IStarringRepository _starringRepository;
        private readonly IFileProvider _fileProvider;

        public MovieController(IMovieRepository movieRepository, IMapper mapper, ICategoryRepository categoryRepository, IDirectorRepository directorRepository, ILanguageRepository languageRepository, IStarringRepository starringRepository, IFileProvider fileProvider)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
            _categoryRepository = categoryRepository;
            _directorRepository = directorRepository;
            _languageRepository = languageRepository;
            _starringRepository = starringRepository;
            _fileProvider = fileProvider;
        }


        public IActionResult Index()
        {
            List<MovieVM> movies = new List<MovieVM>();
            foreach (var item in _movieRepository.GetAll())
            {
                movies.Add(_mapper.Map<MovieVM>(item));
            }
            return View(movies);

        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_categoryRepository.GetAll(), "Id", "Name");
            ViewBag.Directors = new SelectList(_directorRepository.GetAll(), "Id", "FullName");
            ViewBag.Language = new SelectList(_languageRepository.GetAll(), "Id", "Name");
            ViewBag.AddStarrignsIds = new SelectList(_starringRepository.GetAll(), "Id", "FullName");
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(MovieVM model)
        {

            if (ModelState.IsValid)
            {
                var newMovie = (_mapper.Map<Movie>(model));

                if (model.Image is not null && model.Image.Length > 0)
                {
                    var root = _fileProvider.GetDirectoryContents("wwwroot");
                    var images = root.First(x => x.Name == "Images");

                    var randomImageName = Guid.NewGuid() + Path.GetExtension(model.Image.FileName);

                    var path = Path.Combine(images.PhysicalPath, randomImageName);

                    using var stream = new FileStream(path, FileMode.Create);
                    model.Image.CopyTo(stream);
                    newMovie.ImagePath = randomImageName;

                }

                foreach (var item in model.AddStarrignsIds)
                {
                    newMovie.Starrings.Add(_starringRepository.GetById(item));
                }

                _movieRepository.Add(newMovie);
                TempData["Succes"] = "Nev Movie is added successfully";
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(_categoryRepository.GetAll(), "Id", "Name");
            ViewBag.Directors = new SelectList(_directorRepository.GetAll(), "Id", "FullName");
            ViewBag.Language = new SelectList(_languageRepository.GetAll(), "Id", "Name");
            ViewBag.AddStarrignsIds = new SelectList(_starringRepository.GetAll(), "Id", "FullName");
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var starringsThatInPlayMovie = _movieRepository.GetById(id).Starrings;
            var starringsThatNotInPlayMovie = _starringRepository.GetAll().Except(starringsThatInPlayMovie);

            ViewBag.Categories = new SelectList(_categoryRepository.GetAll(), "Id", "Name");
            ViewBag.Directors = new SelectList(_directorRepository.GetAll(), "Id", "FullName");
            ViewBag.Language = new SelectList(_languageRepository.GetAll(), "Id", "Name");
            ViewBag.DeleteStarrignsIds = new SelectList(starringsThatInPlayMovie, "Id", "FullName");
            ViewBag.AddStarrignsIds = new SelectList(starringsThatNotInPlayMovie, "Id", "FullName");

            return View(_mapper.Map<MovieVM>(_movieRepository.GetById(id)));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(MovieVM model)
        {

            if (ModelState.IsValid)
            {

                if (model.Image is not null && model.Image.Length > 0)
                {
                    var root = _fileProvider.GetDirectoryContents("wwwroot");
                    var images = root.First(x => x.Name == "Images");

                    var randomImageName = Guid.NewGuid() + Path.GetExtension(model.Image.FileName);

                    var path = Path.Combine(images.PhysicalPath, randomImageName);

                    using var stream = new FileStream(path, FileMode.Create);
                    model.Image.CopyTo(stream);
                    model.ImagePath = randomImageName;

                }

               
                foreach (var item in model.AddStarrignsIds)
                {
                    model.Starrings.Add(_starringRepository.GetById(item));
                }
                foreach (var item in model.DeleteStarrignsIds)
                {
                    if (item != null)
                    { 
                        model.Starrings.Remove(_starringRepository.GetById(item));
                    }
                }

                _movieRepository.Update(_mapper.Map<Movie>(model));
                TempData["Succes"] = "Movie is updated successfully";
                return RedirectToAction("Index");
            }

            var starringsThatInPlayMovie = _movieRepository.GetById((int)model.Id).Starrings;
            var starringsThatNotInPlayMovie = _starringRepository.GetAll().Except(starringsThatInPlayMovie);

            ViewBag.Categories = new SelectList(_categoryRepository.GetAll(), "Id", "Name");
            ViewBag.Directors = new SelectList(_directorRepository.GetAll(), "Id", "FullName");
            ViewBag.Language = new SelectList(_languageRepository.GetAll(), "Id", "Name");
            ViewBag.DeleteStarrignsIds = new SelectList(starringsThatInPlayMovie, "Id", "FullName");
            ViewBag.AddStarrignsIds = new SelectList(starringsThatNotInPlayMovie, "Id", "FullName");
            return View(model);

        }


        public IActionResult Delete(int id)
        {
            ViewBag.Starrings = new SelectList(_movieRepository.GetById(id).Starrings, "Id", "FullName");
            return View(_mapper.Map<MovieVM>(_movieRepository.GetById(id)));
        }

        [HttpPost]
        [ActionName("Delete"), ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _movieRepository.Delete(id);
            return RedirectToAction("Index");

        }

        public IActionResult Details(int id)
        {
            ViewBag.Starrings = new SelectList(_movieRepository.GetById(id).Starrings, "Id", "FullName");
            TempData["Succes"] = "Movie is deleted successfully";
            return View(_mapper.Map<MovieVM>(_movieRepository.GetById(id)));
        }

    }
}
