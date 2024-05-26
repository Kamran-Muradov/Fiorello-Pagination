using Fiorello_PB101.Data;
using Fiorello_PB101.Helpers;
using Fiorello_PB101.Models;
using Fiorello_PB101.Services.Interfaces;
using Fiorello_PB101.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_PB101.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly AppDbContext _context;


        public CategoryController(
            ICategoryService categoryService,
            AppDbContext context
            )
        {
            _categoryService = categoryService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            var categories = await _categoryService.GetAllPaginateAsync(page, 4);

            var mappedDatas = _categoryService.GetAllMappedDatas(categories);

            int totalPageCount = await GetPageCountAsync(4);

            Paginate<CategoryProductVM> response = new(mappedDatas, totalPageCount, page);

            return View(response);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateVM category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            bool existCategory = await _categoryService.ExistAsync(category.Name);

            if (existCategory)
            {
                ModelState.AddModelError("Name", "This category already exist");
                return View();
            }

            await _categoryService.CreateAsync(new Category { Name = category.Name });

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            var category = await _categoryService.GetByIdAsync((int)id);

            if (category is null) return NotFound();

            await _categoryService.DeleteAsync(category);

            if (category.SoftDeleted)
            {
                return RedirectToAction("CategoryArchive", "Archive");
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null) return BadRequest();

            var category = await _categoryService.GetByIdWithProductsAsync((int)id);

            if (category is null) return NotFound();

            return View(category);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            var category = await _categoryService.GetByIdAsync((int)id);

            if (category is null) return NotFound();

            return View(new CategoryEditVM { Name = category.Name });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, CategoryEditVM request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (id is null) return BadRequest();

            if (await _categoryService.ExistExceptByIdAsync((int)id, request.Name))
            {
                ModelState.AddModelError("Name", "This category already exist");
                return View();
            }

            var category = await _categoryService.GetByIdAsync((int)id);

            if (category is null) return NotFound();

            if (category.Name == request.Name)
            {
                return RedirectToAction(nameof(Index));
            }

            category.Name = request.Name;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> SetToArchive(int? id)
        {
            if (id is null) return BadRequest();

            var category = await _categoryService.GetByIdAsync((int)id);

            if (category is null) return NotFound();

            category.SoftDeleted = true;

            await _context.SaveChangesAsync();

            return Ok(category);
        }

        private async Task<int> GetPageCountAsync(int take)
        {
            int productCount = await _categoryService.GetCountAsync();

            return (int)Math.Ceiling((decimal)productCount / take);
        }
    }

    
}
