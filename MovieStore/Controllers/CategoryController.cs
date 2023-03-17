using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieStore.Models.Entities;
using MovieStore.Models.ViewModels;
using MovieStore.Repository.Abstract;
using MovieStore.Repository.Concerete;

namespace MovieStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

       public IActionResult Index()
        {
            List<CategoryVM> categories = new List<CategoryVM>();
            foreach (var item in _repository.GetAll())
            {
                categories.Add(_mapper.Map<CategoryVM>(item));
            }
            return View(categories);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryVM newCategory)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(_mapper.Map<Category>(newCategory));
                TempData["success"] = "New Category is added successfully";
                return RedirectToAction("Index");
            }
            return View(newCategory);
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            return View(_mapper.Map<CategoryVM>(_repository.GetById(id)));
        }

        [HttpPost]
        public IActionResult Edit(CategoryVM updatedCategory)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(_mapper.Map<Category>(updatedCategory));
                TempData["success"] = "Category is updates successfully";
                return RedirectToAction("Index");
            }
            return View(updatedCategory);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_mapper.Map<CategoryVM>(_repository.GetById(id)));
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteComfirmed(int id)
        {
            _repository.Delete(id);
            TempData["success"] = "Category is deleted successfully";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {


            ViewBag.DirectedMovies = new SelectList(_repository.GetById(id).Movies, "Id", "Name");

            return View(_mapper.Map<CategoryVM>(_repository.GetById(id)));
        }




















    }
}
