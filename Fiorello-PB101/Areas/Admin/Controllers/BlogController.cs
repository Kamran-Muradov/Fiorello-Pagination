using Fiorello_PB101.Data;
using Fiorello_PB101.Helpers.Extensions;
using Fiorello_PB101.Models;
using Fiorello_PB101.Services.Interfaces;
using Fiorello_PB101.ViewModels.Blog;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_PB101.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public BlogController(
            IBlogService blogService,
            AppDbContext context,
            IWebHostEnvironment env
            )
        {
            _blogService = blogService;
            _context = context;
            _env = env;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var blogs = await _blogService.GetAllAsync();
            return View(blogs.OrderByDescending(m => m.Id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogCreateVM request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!request.Image.CheckFileType("image/"))
            {
                ModelState.AddModelError("Image", "Input can accept only image format");
                return View();
            }

            if (!request.Image.CheckFileSize(200))
            {
                ModelState.AddModelError("Image", "Image size must be max 200 KB");
                return View();
            }

            bool existBlog = await _blogService.ExistAsync(request.Title, request.Description);

            if (existBlog)
            {
                ModelState.AddModelError("Title", "Blog with this title or description already exists");
                ModelState.AddModelError("Description", "Blog with this title or description already exists");
                return View();
            }

            await _blogService.CreateAsync(request);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            var blog = await _blogService.GetByIdAsync((int)id);

            if (blog is null) return NotFound();

            return View(new BlogEditVM
            {
                Title = blog.Title,
                Description = blog.Description,
                Image = blog.Image,
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, BlogEditVM request)
        {
            if (id is null) return BadRequest();

            var blog = await _blogService.GetByIdAsync((int)id);

            if (blog is null) return NotFound();

            if (!ModelState.IsValid)
            {
                request.Image = blog.Image;
                return View(request);
            }


            if (await _blogService.ExistExceptByIdAsync((int)id, request.Title, request.Description))
            {
                ModelState.AddModelError("Title", "Blog with this title or description already exists");
                ModelState.AddModelError("Description", "Blog with this title or description already exists");
                request.Image = blog.Image;
                return View(request);
            }

            if (request.NewImage is not null)
            {
                if (!request.NewImage.CheckFileType("image/"))
                {
                    ModelState.AddModelError("NewImage", "Input can accept only image format");
                    request.Image = blog.Image;
                    return View(request);
                }

                if (!request.NewImage.CheckFileSize(200))
                {
                    ModelState.AddModelError("NewImage", "Image size must be max 200 KB");
                    request.Image = blog.Image;
                    return View(request);
                }
            }

            await _blogService.EditAsync((int)id, request);

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            var blog = await _blogService.GetByIdAsync((int)id);

            if (blog is null) return NotFound();

            await _blogService.DeleteAsync(blog.Id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null) return BadRequest();

            var blog = await _blogService.GetByIdAsync((int)id);

            if (blog is null) return NotFound();

            return View(new BlogDetailVM
            {
                Title = blog.Title,
                Description = blog.Description,
                CreatedDate = blog.CreatedDate,
                Image = blog.Image
            });
        }
    }
}
