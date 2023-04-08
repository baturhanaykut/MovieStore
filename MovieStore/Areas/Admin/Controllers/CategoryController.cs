using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieStore_Application.Models.DTOs.CategoryDTOS;
using MovieStore_Application.Services.CategoryServices;

namespace MovieStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
  

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategories();
            
            return View(categories);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCategoryDTO newCategory)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Create(newCategory);
                TempData["success"] = "New Category is added successfully";
                return RedirectToAction("Index");
            }
            return View(newCategory);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _categoryService.GetById(id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateCategoryDTO updatedCategory)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Update(updatedCategory);
                TempData["success"] = "Category is updates successfully";
                return RedirectToAction("Index");
            }
            return View(updatedCategory);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_categoryService.GetById(id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeleteComfirmed(int id)
        {
            _categoryService.Delete(id);
            TempData["success"] = "Category is deleted successfully";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            //To Do : Kontrol Edilecek.
            //ViewBag.DirectedMovies = new SelectList(_categoryService.GetById(id)., "Id", "Name");

            return View(_categoryService.GetById(id));
        }

    }
}

