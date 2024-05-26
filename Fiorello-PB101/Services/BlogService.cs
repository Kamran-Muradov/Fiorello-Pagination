using Fiorello_PB101.Data;
using Fiorello_PB101.Helpers.Extensions;
using Fiorello_PB101.Models;
using Fiorello_PB101.Services.Interfaces;
using Fiorello_PB101.ViewModels.Blog;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_PB101.Services
{
    public class BlogService : IBlogService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;


        public BlogService(
            AppDbContext context,
            IWebHostEnvironment env
            )
        {
            _context = context;
            _env = env;
        }
        public async Task<IEnumerable<BlogVM>> GetAllAsync(int? take = null)
        {
            IEnumerable<Blog> blogs;

            if (take is null)
            {
                blogs = await _context.Blogs.ToListAsync();
            }
            else
            {
                blogs = await _context.Blogs.Take((int)take).ToListAsync();
            }

            return blogs.Select(m => new BlogVM
            {
                Id = m.Id,
                Title = m.Title,
                Description = m.Description,
                Image = m.Image,
                CreatedDate = m.CreatedDate.ToString("MM.dd.yyyy")
            });
        }

        public async Task<BlogVM> GetByIdAsync(int id)
        {
            Blog blog = await _context.Blogs.FirstOrDefaultAsync(m => m.Id == id);

            return new BlogVM
            {
                Id = blog.Id,
                Title = blog.Title,
                Description = blog.Description,
                Image = blog.Image,
                CreatedDate = blog.CreatedDate.ToString("MM.dd.yyyy")
            };
        }

        public async Task CreateAsync(BlogCreateVM request)
        {
            string fileName = Guid.NewGuid().ToString() + "-" + request.Image.FileName;

            string path = _env.GenerateFilePath("img", fileName);

            await request.Image.SaveFileToLocalAsync(path);

            await _context.Blogs.AddAsync(new Blog
            {
                Title = request.Title,
                Description = request.Description,
                Image = fileName
            });

            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, BlogEditVM request)
        {
            var blog = await _context.Blogs.FirstOrDefaultAsync(m => m.Id == id);

            blog.Title = request.Title;

            blog.Description = request.Description;

            if (request.NewImage is not null)
            {
                string oldPath = _env.GenerateFilePath("img", blog.Image);

                oldPath.DeleteFileFromLocal();

                string fileName = Guid.NewGuid().ToString() + "-" + request.NewImage.FileName;

                string newPath = _env.GenerateFilePath("img", fileName);

                await request.NewImage.SaveFileToLocalAsync(newPath);

                blog.Image = fileName;
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var blog = await _context.Blogs.FirstOrDefaultAsync(m => m.Id == id);

            string imgPath = _env.GenerateFilePath("img", blog.Image);
            imgPath.DeleteFileFromLocal();

            _context.Blogs.Remove(blog);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(string title, string description)
        {
            return await _context.Blogs.AnyAsync(m => m.Title.Trim() == title.Trim() || m.Description.Trim() == description.Trim());
        }

        public async Task<bool> ExistExceptByIdAsync(int id, string title, string description)
        {
            return await _context.Blogs.AnyAsync(m => m.Id != id && (m.Title.Trim() == title.Trim() || m.Description.Trim() == description.Trim()));

        }
    }
}
