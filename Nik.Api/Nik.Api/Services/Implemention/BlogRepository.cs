using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Nik.Api.Models;
using Nik.Api.Models.NotMapped;
using Nik.Api.Services.Interfaces;
using Nik.Api.Utilities;
using Nik.Api.Utilities.FileHelpers;

namespace Nik.Api.Services.Implemention
{
    public class BlogRepository : IBlogRepository
    {
        private readonly NikDbContext _context;
        private readonly IFileHelper _fileHelper;
        public BlogRepository(NikDbContext context, IFileHelper fileHelper)
        {
            _context = context;
            _fileHelper = fileHelper;
        }
        public async Task<Blog> DeleteBlog(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null)
            {
                throw new Exception("null");
            }
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return blog;
        }

        public async Task<List<Blog>> GetAllBlogs()
        {
            var result = await _context.Blogs.ToListAsync();
            return result;
        }

        public async Task<Blog> GetBlog(int id)
        {
            var result = await _context.Blogs.FindAsync(id);
            return result;
        }

        public async Task<Blog> PostBlog(Blog blog)
        {
            blog.ImageName = _fileHelper.Upload(blog.FormFile, FilePath.Root);
            Blog blog1 = new Blog()
            {
                DateTime = DateTime.Now,
                Description = blog.Description,
                Tags = blog.Tags,
                Text = blog.Text,
                Title = blog.Title,
                ImageName = blog.ImageName,
            };

            _context.Blogs.Add(blog1);
            await _context.SaveChangesAsync();
            return blog1;
        }

        public void PutBlog(int id, Blog blog)
        {
            blog.ImageName = _fileHelper.Upload(blog.FormFile, FilePath.Root);
            var result = _context.Blogs.Where(g => g.BlogId == id).Select(g => new Blog
            {
                BlogId = id,
                DateTime = blog.DateTime,
                Description = blog.Description,
                ImageName = blog.ImageName,
                Tags = blog.Tags,
                Text = blog.Text,
                Title = blog.Title
            });

            _context.SaveChanges();
        }
    }
}
