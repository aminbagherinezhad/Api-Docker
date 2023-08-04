using Microsoft.EntityFrameworkCore;
using Nik.Api.Models;
using Nik.Api.Models.NotMapped;
using Nik.Api.Services.Interfaces;
using Nik.Api.Utilities;
using Nik.Api.Utilities.FileHelpers;

namespace Nik.Api.Services.Implemention
{
    public class categoryImageRepository : ICategoryImageRepository
    {
        private readonly NikDbContext _context;
        private readonly IFileHelper _fileHelper;
        public categoryImageRepository(NikDbContext context, IFileHelper fileHelper)
        {
            _context = context;
            _fileHelper = fileHelper;
        }

        public async Task deleteCategoryImage(int id)
        {
            var categoryImage = await _context.CategoryImages.FindAsync(id);
            if (categoryImage == null)
            {
                throw new ArgumentException();
            }
            _context.CategoryImages.Remove(categoryImage);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CategoryImage>> getAllCategoryImages()
        {
            return await _context.CategoryImages.ToListAsync();
        }

        public async Task<CategoryImage> getByCategoryImage(int id)
        {
            return await _context.CategoryImages.FindAsync(id);
        }

        public Task<CategoryImage> postCategoryImage(CategoryImage categoryImage)
        {
            categoryImage.ImageName = _fileHelper.Upload(categoryImage.FormFile, FilePath.Root);
            CategoryImage categoryimg = new CategoryImage()
            {
                CategoryId = categoryImage.CategoryId,
                ImageName = categoryImage.ImageName,
            };

            _context.CategoryImages.Add(categoryimg);
            _context.SaveChangesAsync();
            return Task.FromResult(categoryimg);
        }

        public Task putCategoryImage(int id, CategoryImage categoryImage)
        {
            throw new NotImplementedException();
        }
    }
}
