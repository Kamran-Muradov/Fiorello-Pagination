using Fiorello_PB101.Models;
using Fiorello_PB101.ViewModels.Blog;

namespace Fiorello_PB101.Services.Interfaces
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogVM>> GetAllAsync(int? take = null);
        Task<BlogVM> GetByIdAsync(int id);
        Task CreateAsync(BlogCreateVM request);
        Task EditAsync(int id,BlogEditVM request);
        Task DeleteAsync(int id);
        Task<bool> ExistAsync(string title, string description);
        Task<bool> ExistExceptByIdAsync(int id, string title, string description);

    }
}
