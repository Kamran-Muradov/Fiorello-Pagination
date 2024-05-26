using Fiorello_PB101.Data;
using Fiorello_PB101.Models;
using Fiorello_PB101.Services.Interfaces;
using Fiorello_PB101.ViewModels.Categories;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_PB101.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<IEnumerable<CategoryArchiveVM>> GetAllArchivePaginateAsync(int page, int take)
        {
            IEnumerable<Category> categories = await _context.Categories
                .IgnoreQueryFilters()
                .Where(m => m.SoftDeleted)
                .OrderByDescending(m => m.Id)
                .Skip((page - 1) * take)
                .Take(take)
                .ToListAsync();

            return categories.Select(m => new CategoryArchiveVM
            {
                Id = m.Id,
                CategoryName = m.Name,
                CreatedDate = m.CreatedDate.ToString("MM.dd.yyyy")
            });
        }

        public async Task<IEnumerable<CategoryProductVM>> GetAllWithProductCountAsync()
        {
            IEnumerable<Category> categories = await _context.Categories
                .Include(m => m.Products)
                .OrderByDescending(m => m.Id)
                .ToListAsync();

            return categories.Select(m => new CategoryProductVM
            {
                Id = m.Id,
                CategoryName = m.Name,
                ProductCount = m.Products.Count,
                CreatedDate = m.CreatedDate.ToString("MM.dd.yyyy")
            });
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Categories.CountAsync();
        }

        public async Task<int> GetArchiveCountAsync()
        {
            return await _context.Categories
                .IgnoreQueryFilters()
                .Where(m => m.SoftDeleted)
                .CountAsync();
        }

        public IEnumerable<CategoryProductVM> GetAllMappedDatas(IEnumerable<Category> categories)
        {
            return categories.Select(m => new CategoryProductVM
            {
                Id = m.Id,
                CategoryName = m.Name,
                ProductCount = m.Products.Count,
                CreatedDate = m.CreatedDate.ToString("MM.dd.yyyy")
            });
        }

        public async Task<IEnumerable<Category>> GetAllPaginateAsync(int page, int take)
        {
            return await _context.Categories
                .OrderByDescending(m => m.Id)
                .Skip((page - 1) * take)
                .Take(take)
                .Include(m => m.Products)
                .ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<CategoryDetailVM> GetByIdWithProductsAsync(int id)
        {
            var category = await _context.Categories
                .Where(m => m.Id == id)
                .Include(m => m.Products)
                .FirstOrDefaultAsync();

            return new CategoryDetailVM
            {
                Name = category.Name,
                CreatedDate = category.CreatedDate.ToString("MM.dd.yyyy"),
                Products = category.Products.Select(m => m.Name).ToList(),
                ProductCount = category.Products.Count
            };
        }

        public async Task<bool> ExistAsync(string name)
        {
            return await _context.Categories.AnyAsync(m => m.Name.Trim() == name.Trim());
        }

        public async Task CreateAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistExceptByIdAsync(int id, string name)
        {
            return await _context.Categories.AnyAsync(m => m.Name == name && m.Id != id);
        }
    }
}
