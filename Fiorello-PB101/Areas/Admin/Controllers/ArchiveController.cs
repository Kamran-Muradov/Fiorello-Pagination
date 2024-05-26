using Fiorello_PB101.Data;
using Fiorello_PB101.Helpers;
using Fiorello_PB101.Services.Interfaces;
using Fiorello_PB101.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_PB101.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArchiveController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly AppDbContext _context;

        public ArchiveController(
            ICategoryService categoryService,
            AppDbContext context
        )
        {
            _categoryService = categoryService;
            _context = context;
        }

        public async Task<IActionResult> CategoryArchive(int page = 1)
        {
            var mappedDatas = await _categoryService.GetAllArchivePaginateAsync(page, 4);

            int totalPageCount = await GetPageCountAsync(4);

            Paginate<CategoryArchiveVM> response = new(mappedDatas, totalPageCount, page);

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Restore(int? id)
        {
            if (id is null) return BadRequest();

            var category = await _categoryService.GetByIdAsync((int)id);

            if (category is null) return NotFound();

            category.SoftDeleted = false;

            await _context.SaveChangesAsync();

            return Ok(category);
        }

        private async Task<int> GetPageCountAsync(int take)
        {
            int productCount = await _categoryService.GetArchiveCountAsync();

            return (int)Math.Ceiling((decimal)productCount / take);
        }
    }
}
