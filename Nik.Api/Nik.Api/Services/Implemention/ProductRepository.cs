using Microsoft.EntityFrameworkCore;
using Nik.Api.Models;
using Nik.Api.Models.NotMapped;
using Nik.Api.Services.Interfaces;
using Nik.Api.Utilities;
using Nik.Api.Utilities.FileHelpers;

namespace Nik.Api.Services.Implemention
{
    public class ProductRepository : IProductRepository
    {
        private readonly NikDbContext _context;
        private readonly IFileHelper _fileHelper;
        public ProductRepository(NikDbContext context, IFileHelper fileHelper)
        {
            _context = context;
            _fileHelper = fileHelper;
        }
        public async Task deleteProduct(int id)
        {
            var result = await _context.Products.FindAsync(id);
            _context.Products.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> getAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> getByIdAsync(int id)
        {
            var result = await _context.Products.FindAsync(id);
            return result;
        }

        public async Task<Product> postProduct(Product product)
        {
            product.ImageName = _fileHelper.Upload(product.FormFile, FilePath.Root);
            Product product1 = new Product()
            {
                CategoryId = product.CategoryId,
                DateTime = DateTime.Now,
                Description = product.Description,
                Tags = product.Tags,
                Text = product.Text,
                Title = product.Title,
                ImageName = product.ImageName,
            };

            _context.Products.Add(product1);
            _context.SaveChangesAsync();
            return product1;
        }

        public Task putProduct(int id, Product product)
        {
            product.ImageName = _fileHelper.Upload(product.FormFile, FilePath.Root);
            _context.Products.Where(c => c.ProductId == id).Select(c => new Product
            {
                ProductId = id,
                DateTime = DateTime.Now,
                Title = product.Title,
                CategoryId = product.CategoryId,
                Description = product.Description,
                Tags = product.Tags,
                Text = product.Text,

            });

            _context.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
