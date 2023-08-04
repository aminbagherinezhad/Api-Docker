using Nik.Api.Models;

namespace Nik.Api.Services.Interfaces
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllBlogs();
        Task<Blog> GetBlog(int id);
        void PutBlog(int id, Blog blog);
        Task<Blog> PostBlog(Blog blog);
        Task<Blog> DeleteBlog(int id);

    }
}
