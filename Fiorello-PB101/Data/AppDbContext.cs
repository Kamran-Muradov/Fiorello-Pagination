using Fiorello_PB101.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_PB101.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderInfo> SliderInfos { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Social> Socials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Slider>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Blog>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Expert>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(m => !m.SoftDeleted);
            modelBuilder.Entity<Product>().HasQueryFilter(m => !m.SoftDeleted);

            modelBuilder.Entity<Blog>().HasData(
                new Blog
                {
                    Id = 1,
                    Title = "Title1",
                    Description = "Reshadin blogu",
                    Image = "blog-feature-img-1.jpg",
                    CreatedDate = DateTime.Now
                },
                new Blog
                {
                    Id = 2,
                    Title = "Title2",
                    Description = "Ilqarin blogu",
                    Image = "blog-feature-img-3.jpg",
                    CreatedDate = DateTime.Now
                },
                new Blog
                {
                    Id = 3,
                    Title = "Title3",
                    Description = "Hacixanin blogu",
                    Image = "blog-feature-img-4.jpg",
                    CreatedDate = DateTime.Now
                }
            );

            modelBuilder.Entity<Setting>().HasData(
                new Setting
                {
                    Id = 1,
                    Key = "HeaderLogo",
                    Value = "logo.png",
                    SoftDeleted = false,
                    CreatedDate = DateTime.Now
                },
                new Setting
                {
                    Id = 2,
                    Key = "Phone",
                    Value = "234342334",
                    SoftDeleted = false,
                    CreatedDate = DateTime.Now
                },
                new Setting
                {
                    Id = 3,
                    Key = "Address",
                    Value = "Ehmedli",
                    SoftDeleted = false,
                    CreatedDate = DateTime.Now
                }
            );

            modelBuilder.Entity<Social>().HasData(
                new Social
                {
                    Id = 1,
                    Name = "Twitter",
                    Icon = "<svg  xmlns=\"http://www.w3.org/2000/svg\"  width=\"15\"  height=\"15\"  viewBox=\"0 0 24 24\"  fill=\"none\"  stroke=\"currentColor\"  stroke-width=\"2\"  stroke-linecap=\"round\"  stroke-linejoin=\"round\"  class=\"icon icon-tabler icons-tabler-outline icon-tabler-brand-x\"><path stroke=\"none\" d=\"M0 0h24v24H0z\" fill=\"none\"/><path d=\"M4 4l11.733 16h4.267l-11.733 -16z\" /><path d=\"M4 20l6.768 -6.768m2.46 -2.46l6.772 -6.772\" /></svg>",
                    URL = "https://x.com/",
                    SoftDeleted = false,
                    CreatedDate = DateTime.Now
                },
                new Social
                {
                    Id = 2,
                    Name = "Instagram",
                    Icon = "<svg  xmlns=\"http://www.w3.org/2000/svg\"  width=\"15\"  height=\"15\"  viewBox=\"0 0 24 24\"  fill=\"none\"  stroke=\"currentColor\"  stroke-width=\"2\"  stroke-linecap=\"round\"  stroke-linejoin=\"round\"  class=\"icon icon-tabler icons-tabler-outline icon-tabler-brand-instagram\"><path stroke=\"none\" d=\"M0 0h24v24H0z\" fill=\"none\"/><path d=\"M4 4m0 4a4 4 0 0 1 4 -4h8a4 4 0 0 1 4 4v8a4 4 0 0 1 -4 4h-8a4 4 0 0 1 -4 -4z\" /><path d=\"M12 12m-3 0a3 3 0 1 0 6 0a3 3 0 1 0 -6 0\" /><path d=\"M16.5 7.5l0 .01\" /></svg>",
                    URL = "https://www.instagram.com/",
                    SoftDeleted = false,
                    CreatedDate = DateTime.Now
                },
                new Social
                {
                    Id = 3,
                    Name = "Tumblr",
                    Icon = "<svg  xmlns=\"http://www.w3.org/2000/svg\"  width=\"15\"  height=\"15\"  viewBox=\"0 0 24 24\"  fill=\"none\"  stroke=\"currentColor\"  stroke-width=\"2\"  stroke-linecap=\"round\"  stroke-linejoin=\"round\"  class=\"icon icon-tabler icons-tabler-outline icon-tabler-brand-tumblr\"><path stroke=\"none\" d=\"M0 0h24v24H0z\" fill=\"none\"/><path d=\"M14 21h4v-4h-4v-6h4v-4h-4v-4h-4v1a3 3 0 0 1 -3 3h-1v4h4v6a4 4 0 0 0 4 4\" /></svg>",
                    URL = "https://www.tumblr.com/",
                    SoftDeleted = false,
                    CreatedDate = DateTime.Now
                },
                new Social
                {
                    Id = 4,
                    Name = "Pinterest",
                    Icon = "<svg  xmlns=\"http://www.w3.org/2000/svg\"  width=\"15\"  height=\"15\"  viewBox=\"0 0 24 24\"  fill=\"none\"  stroke=\"currentColor\"  stroke-width=\"2\"  stroke-linecap=\"round\"  stroke-linejoin=\"round\"  class=\"icon icon-tabler icons-tabler-outline icon-tabler-brand-pinterest\"><path stroke=\"none\" d=\"M0 0h24v24H0z\" fill=\"none\"/><path d=\"M8 20l4 -9\" /><path d=\"M10.7 14c.437 1.263 1.43 2 2.55 2c2.071 0 3.75 -1.554 3.75 -4a5 5 0 1 0 -9.7 1.7\" /><path d=\"M12 12m-9 0a9 9 0 1 0 18 0a9 9 0 1 0 -18 0\" /></svg>",
                    URL = "https://www.pinterest.com/",
                    SoftDeleted = false,
                    CreatedDate = DateTime.Now
                }
            );
        }
    }
}
